namespace finito
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            raketikilabel = new Label();
            raketbirlabel = new Label();
            ball = new PictureBox();
            raketiki = new PictureBox();
            raketbir = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            ((System.ComponentModel.ISupportInitialize)raketiki).BeginInit();
            ((System.ComponentModel.ISupportInitialize)raketbir).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(raketikilabel);
            panel1.Controls.Add(raketbirlabel);
            panel1.Controls.Add(ball);
            panel1.Controls.Add(raketiki);
            panel1.Controls.Add(raketbir);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(760, 420);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // raketikilabel
            // 
            raketikilabel.AutoSize = true;
            raketikilabel.Location = new Point(438, 37);
            raketikilabel.Name = "raketikilabel";
            raketikilabel.Size = new Size(13, 15);
            raketikilabel.TabIndex = 4;
            raketikilabel.Text = "0";
            // 
            // raketbirlabel
            // 
            raketbirlabel.AutoSize = true;
            raketbirlabel.Location = new Point(231, 37);
            raketbirlabel.Name = "raketbirlabel";
            raketbirlabel.Size = new Size(13, 15);
            raketbirlabel.TabIndex = 3;
            raketbirlabel.Text = "0";
            // 
            // ball
            // 
            ball.BackColor = SystemColors.ActiveCaption;
            ball.Location = new Point(360, 224);
            ball.Name = "ball";
            ball.Size = new Size(41, 31);
            ball.TabIndex = 2;
            ball.TabStop = false;
            // 
            // raketiki
            // 
            raketiki.BackColor = SystemColors.AppWorkspace;
            raketiki.Location = new Point(698, 151);
            raketiki.Name = "raketiki";
            raketiki.Size = new Size(37, 90);
            raketiki.TabIndex = 1;
            raketiki.TabStop = false;
            // 
            // raketbir
            // 
            raketbir.BackColor = SystemColors.ActiveBorder;
            raketbir.Location = new Point(30, 151);
            raketbir.Name = "raketbir";
            raketbir.Size = new Size(41, 90);
            raketbir.TabIndex = 0;
            raketbir.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ((System.ComponentModel.ISupportInitialize)raketiki).EndInit();
            ((System.ComponentModel.ISupportInitialize)raketbir).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label raketikilabel;
        private Label raketbirlabel;
        private PictureBox ball;
        private PictureBox raketiki;
        private PictureBox raketbir;
        private System.Windows.Forms.Timer timer1;
    }
}