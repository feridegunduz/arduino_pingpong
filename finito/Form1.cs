using System.IO.Ports;

namespace finito
{
    public partial class Form1 : Form
    {
        SerialPort seri = new SerialPort();
        Random rnd = new Random();
        int raket1Y;
        int raket2Y;
        int ballhizX = 2;
        int ballhizY = 2;
        int raket1skor;
        int raket2skor;

        public object ResetBallPosition { get; private set; }

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Oyunun baþlangýç ayarlarý
            raket1Y = (panel1.Height / 2) - (raketbir.Height / 2);
            raket2Y = (panel1.Height / 2) - (raketiki.Height / 2);
            ball.Location = new Point(panel1.Width / 2 - ball.Width / 2, panel1.Height / 2 - ball.Height / 2);
            //ballhizX = rnd.Next(2, 4) * (rnd.Next(0, 2) * 2 - 1);
            ballhizX = 10;
            //ballhizY = rnd.Next(2, 4) * (rnd.Next(0, 2) * 2 - 1);
            ballhizY = 10;
            raket1skor = 0;
            raket2skor = 0;

        }
        //Seri Port Giriþi
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                seri = new SerialPort("COM5", 9600);
                seri.Open();
                seri.DataReceived += new SerialDataReceivedEventHandler(seri_DataReceived);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timer1.Start();
        }

        private void seri_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string veri = sp.ReadLine();

            try
            {
                string val = seri.ReadLine().Trim('\r');
                string[] values = val.Split(' ');

                if (values.Length == 6)
                {
                    int x1Pozisyon = int.Parse(values[0]);
                    int y1Pozisyon = int.Parse(values[1]);
                    int x2Pozisyon = int.Parse(values[3]);
                    int y2Pozisyon = int.Parse(values[4]);

                    raketY[0] = y1Pozisyon;
                    raketY[1] = y2Pozisyon;

                    //Console.WriteLine($"x1Pozisyon: {x1Pozisyon}, y1Pozisyon: {y1Pozisyon}");
                    //Console.WriteLine($"x2Pozisyon: {x2Pozisyon}, y2Pozisyon: {y2Pozisyon}");

                    if (x1Pozisyon == 512 && y1Pozisyon == 1023)
                    {
                        // Joystick 1, Raket 1 için YUKARI hareket kodu
                        raketbir.Top -= 5;
                    }
                    else if (x1Pozisyon == 512 && y1Pozisyon == 0)
                    {
                        // Joystick 1, Raket 1 için AÞAÐI hareket kodu
                        raketbir.Top += 5;
                    }

                    if (x2Pozisyon == 512 && y2Pozisyon == 1023)
                    {
                        // Joystick 2, Raket 2 için YUKARI hareket kodu
                        raketiki.Top -= 5;
                    }
                    else if (x2Pozisyon == 512 && y2Pozisyon == 0)
                    {
                        // Joystick 2, Raket 2 için AÞAÐI hareket kodu
                        raketiki.Top += 5;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (seri != null)
            {
                seri.Close();
            }
        }

        private void raketiki_Click(object sender, EventArgs e)
        {

        }

        private void ball_Click(object sender, EventArgs e)
        {

        }

        private void raketbir_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void raketbirlabel_Click(object sender, EventArgs e)
        {

        }

        private void raketikilabel_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBall();
            MoveRackets();
            CheckScores();
            UpdateUI();

        }

        private void MoveBall()
        {
            //Topun hareketini belirlemek için topun sol ve üst pozisyonlarýna belirli hýzlarý ekliyor. Bu, topun belirli bir hýzda hareket etmesini saðlar.
            ball.Left += ballhizX;
            ball.Top += ballhizY;


            //Duvara çarptýðýný kontrol et. 
            if (ball.Top <= panel1.Top || ball.Bottom >= panel1.Bottom)
                ballhizY *= -1;

            ////Raketlerle çarpýþma kontrolü yapýlýyor. 
            if (ball.Bounds.IntersectsWith(raketbir.Bounds) || ball.Bounds.IntersectsWith(raketiki.Bounds))
            {
                ballhizX *= -1;
                //ballhizY = rnd.Next(-1, 2);
            }
            if (ball.Bounds.IntersectsWith(raketiki.Bounds) || ball.Bounds.IntersectsWith(raketbir.Bounds))
            {
                ballhizY *= -1;
                //ballhizY = rnd.Next(-1, 2);
            }

            ////Skor kontrolü 
            if (ball.Left <= panel1.Left)
            {
                UpdateScore(ref raket2skor);
                ResetBallPosition1();
            }
            else if (ball.Right >= panel1.Right)
            {
                UpdateScore1(ref raket1skor);
                ResetBallPosition1();
            }
        }

        int[] raketY = new int[2]; // Ýki raket için Y pozisyonlarýný saklayacak dizi
        private void MoveRackets()
        {
            int raketHareketMin = 0;
            int raketHareketMax = panel1.Height - raketbir.Height - 5;

            for (int i = 0; i < 2; i++)
            {
                int normalizedY = Normalize(raketY[i], 0, 1023, raketHareketMin, raketHareketMax);

                if (normalizedY < 0)
                    normalizedY = 0;

                // Raket sýnýrlarýný kontrol etme
                if (i == 0)
                {
                    if (normalizedY + raketbir.Height > panel1.Height - 10) // Varsayýlan olarak raket1'in yüksekliði kullanýlýyor
                        normalizedY = panel1.Height - raketbir.Height - 50;
                    raketbir.Top = normalizedY;
                }
                else if (i == 1)
                {
                    if (normalizedY > panel1.Height - raketiki.Height) // Varsayýlan olarak raket2'in yüksekliði kullanýlýyor
                        normalizedY = panel1.Height - raketiki.Height - 10;
                    raketiki.Top = normalizedY;
                }
            }
        }

        private int Normalize(int value, int minInput, int maxInput, int minOutput, int maxOutput)
        {
            return (value - minInput) * (maxOutput - minOutput) / (maxInput - minInput) + minOutput;
        }
        private void CheckScores()
        {
            // Etiketlerin Tag özelliklerini karþýlaþtýrma
            if (raket1skor == 5 || raket2skor == 5)
            {
                // Oyunu bitirme iþlemleri
                timer1.Stop(); // Zamanlayýcýyý durdur

                // Skora göre kazananý belirleme
                string winner = (raket1skor == 5) ? "Player 1" : "Player 2";

                // Kazananý ekrana yazdýrma
                MessageBox.Show($"{winner} wins!", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Oyunu sýfýrlama iþlemleri
                InitializeGame(); // Oyunu yeniden baþlat

                raket1skor = 0;
                raket2skor = 0;
            }
        }

        //Skoru düzenleme
        private void UpdateUI()
        {
            UpdateScores();
        }

        private void UpdateScores()
        {
            raketikilabel.Text = raket2skor.ToString();
            raketbirlabel.Text = raket1skor.ToString();
        }
        private void UpdateScore(ref int raket2skor)
        {
            raket2skor++;
        }
        private void UpdateScore1(ref int raket1skor)
        {
            raket1skor++;
        }

        private void ResetBallPosition1()
        {
            ball.Location = new Point(panel1.Width / 2 - ball.Width / 2, panel1.Height / 2 - ball.Height / 2);
        }
    }

}