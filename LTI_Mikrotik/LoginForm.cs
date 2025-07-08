using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LTI_Mikrotik
{
    public partial class LoginForm : Form
    {
        private List<Device> devices = new List<Device>();

        public LoginForm()
        {
            InitializeComponent();
            password.PasswordChar = '●';
            LoadDevicesFromDatabase();

            username.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            password.KeyDown += new KeyEventHandler(OnKeyDownHandler);
            listBox1.KeyDown += new KeyEventHandler(OnKeyDownHandler);
        }

        private void OnKeyDownHandler(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Click_1(sender ?? this, e);
            }
        }



        private async void LoadDevicesFromDatabase()
        {
            using (var context = new LTI_Mikrotik.Data.AppDbContext())
            {
                devices = await context.Devices.ToListAsync();
            }

            listBox1.Items.Clear();
            foreach (var device in devices)
            {
                listBox1.Items.Add($"{device.name} ({device.ipAddress}) - {device.username}");
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && listBox1.SelectedIndex < devices.Count)
            {
                var selecionado = devices[listBox1.SelectedIndex];
                name.Text = selecionado.name;
                ipAddress.Text = selecionado.ipAddress;
                username.Text = selecionado.username;

                string encryptionKey = "ChaveSimetrica123"; 
                try
                {
                    password.Text = DecryptPassword(selecionado.password, encryptionKey);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao descriptografar a senha: {ex.Message}");
                    password.Text = string.Empty; 
                }
            }
        }

        private string EncryptPassword(string plainText, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(16).Substring(0, 16));
                aes.GenerateIV(); 

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length); 
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var writer = new StreamWriter(cs))
                    {
                        writer.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        private string DecryptPassword(string cipherText, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key.PadRight(16).Substring(0, 16)); 

                var cipherBytes = Convert.FromBase64String(cipherText);
                using (var ms = new MemoryStream(cipherBytes))
                {
                    var iv = new byte[16];
                    ms.Read(iv, 0, iv.Length); 
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        private async void Login_Click_1(object sender, EventArgs e)
        {
            string encryptionKey = "ChaveSimetrica123"; 
            string nameValue = name.Text.Trim();
            string ipAddressValue = ipAddress.Text.Trim();
            string usernameValue = username.Text.Trim();
            string passwordValue = password.Text;

            if (string.IsNullOrWhiteSpace(nameValue) ||
                string.IsNullOrWhiteSpace(ipAddressValue) ||
                string.IsNullOrWhiteSpace(usernameValue) ||
                string.IsNullOrWhiteSpace(passwordValue))
            {
                MessageBox.Show("Preencha todos os campos antes de iniciar sessão.");
                return;
            }

            var encryptedPassword = EncryptPassword(passwordValue, encryptionKey);

            var device = new Device
            {
                name = nameValue,
                ipAddress = ipAddressValue,
                username = usernameValue,
                password = encryptedPassword
            };

            bool sucesso = await ConnectToDevice(new Device
            {
                name = device.name,
                ipAddress = device.ipAddress,
                username = device.username,
                password = DecryptPassword(device.password, encryptionKey)
            });

            if (sucesso)
            {
                MessageBox.Show("Login efetuado com sucesso!");
                using (var context = new LTI_Mikrotik.Data.AppDbContext())
                {
                    var existingDevice = await context.Devices
                        .FirstOrDefaultAsync(d => d.name == device.name && d.ipAddress == device.ipAddress);

                    if (existingDevice != null)
                    {
                        return;
                    }

                    context.Devices.Add(device);
                    await context.SaveChangesAsync();
                }
                listBox1.Items.Clear();
                devices.Add(device);
                foreach (var d in devices)
                {
                    listBox1.Items.Add($"{d.name} ({d.ipAddress}) - {d.username}");
                    System.Diagnostics.Debug.WriteLine($"Nome: {d.name}");
                    System.Diagnostics.Debug.WriteLine($"IP: {d.ipAddress}");
                    System.Diagnostics.Debug.WriteLine($"Username: {d.username}");
                    System.Diagnostics.Debug.WriteLine("------------------------------");
                }
            }
        }

        private async Task<bool> ConnectToDevice(Device device)
        {
            var urlLogin = $"https://{device.ipAddress}/rest/interface";

            var byteArray = Encoding.ASCII.GetBytes($"{device.username}:{device.password}");

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(urlLogin);
                    System.Diagnostics.Debug.WriteLine(response.StatusCode);

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        MainForm form1 = new MainForm(device);
                        form1.FormClosed += (s, args) =>
                        {
                            username.Text = "";
                            password.Text = "";
                            this.Show();
                        };

                        form1.Show();
                        this.Hide();

                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Login falhou para {device.name}: credenciais inválidas.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro na ligação com {device.name}: " + ex.Message);
                    return false;
                }
            }
        }

    }


}
