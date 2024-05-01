namespace WindowsFormsApp1
{
     partial class Form1
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
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
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               this.lblState = new System.Windows.Forms.Label();
               this.richText = new System.Windows.Forms.RichTextBox();
               this.txtHashResult = new System.Windows.Forms.TextBox();
               this.btnSimulationCalculation = new System.Windows.Forms.Button();
               this.label2 = new System.Windows.Forms.Label();
               this.txtMsg = new System.Windows.Forms.TextBox();
               this.label3 = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               this.setSleepTime = new System.Windows.Forms.Button();
               this.textBox1 = new System.Windows.Forms.TextBox();
               this.label4 = new System.Windows.Forms.Label();
               this.SuspendLayout();
               // 
               // lblState
               // 
               this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.lblState.AutoSize = true;
               this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
               this.lblState.Location = new System.Drawing.Point(13, 248);
               this.lblState.Name = "lblState";
               this.lblState.Size = new System.Drawing.Size(24, 20);
               this.lblState.TabIndex = 28;
               this.lblState.Text = "...";
               this.lblState.Click += new System.EventHandler(this.lblState_Click);
               // 
               // richText
               // 
               this.richText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.richText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
               this.richText.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.richText.ForeColor = System.Drawing.Color.Blue;
               this.richText.Location = new System.Drawing.Point(13, 282);
               this.richText.Name = "richText";
               this.richText.Size = new System.Drawing.Size(819, 367);
               this.richText.TabIndex = 27;
               this.richText.Text = "";
               // 
               // txtHashResult
               // 
               this.txtHashResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.txtHashResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.txtHashResult.Location = new System.Drawing.Point(212, 184);
               this.txtHashResult.Name = "txtHashResult";
               this.txtHashResult.Size = new System.Drawing.Size(624, 29);
               this.txtHashResult.TabIndex = 26;
               // 
               // btnSimulationCalculation
               // 
               this.btnSimulationCalculation.BackColor = System.Drawing.Color.Green;
               this.btnSimulationCalculation.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.btnSimulationCalculation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
               this.btnSimulationCalculation.Location = new System.Drawing.Point(13, 146);
               this.btnSimulationCalculation.Name = "btnSimulationCalculation";
               this.btnSimulationCalculation.Size = new System.Drawing.Size(363, 35);
               this.btnSimulationCalculation.TabIndex = 25;
               this.btnSimulationCalculation.Text = "Simulation Of Hash Calculation";
               this.btnSimulationCalculation.UseVisualStyleBackColor = false;
               this.btnSimulationCalculation.Click += new System.EventHandler(this.btnSimulationCalculation_Click);
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label2.Location = new System.Drawing.Point(13, 112);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(159, 26);
               this.label2.TabIndex = 23;
               this.label2.Text = "Input (Message):";
               // 
               // txtMsg
               // 
               this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
               this.txtMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.txtMsg.Location = new System.Drawing.Point(175, 111);
               this.txtMsg.Name = "txtMsg";
               this.txtMsg.Size = new System.Drawing.Size(661, 29);
               this.txtMsg.TabIndex = 22;
               this.txtMsg.Text = "abc";
               // 
               // label3
               // 
               this.label3.BackColor = System.Drawing.Color.Maroon;
               this.label3.Dock = System.Windows.Forms.DockStyle.Top;
               this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label3.Location = new System.Drawing.Point(0, 85);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(848, 10);
               this.label3.TabIndex = 21;
               this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // label1
               // 
               this.label1.BackColor = System.Drawing.SystemColors.Control;
               this.label1.Dock = System.Windows.Forms.DockStyle.Top;
               this.label1.Font = new System.Drawing.Font("Berlin Sans FB", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(0, 0);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(848, 85);
               this.label1.TabIndex = 20;
               this.label1.Text = "Sha256 Simulation";
               this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
               // 
               // setSleepTime
               // 
               this.setSleepTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.setSleepTime.BackColor = System.Drawing.Color.Green;
               this.setSleepTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.setSleepTime.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
               this.setSleepTime.Location = new System.Drawing.Point(664, 241);
               this.setSleepTime.Name = "setSleepTime";
               this.setSleepTime.Size = new System.Drawing.Size(172, 35);
               this.setSleepTime.TabIndex = 25;
               this.setSleepTime.Text = "Set Speed";
               this.setSleepTime.UseVisualStyleBackColor = false;
               this.setSleepTime.Click += new System.EventHandler(this.setSleepTime_Click);
               // 
               // textBox1
               // 
               this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
               this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.textBox1.Location = new System.Drawing.Point(546, 244);
               this.textBox1.Name = "textBox1";
               this.textBox1.Size = new System.Drawing.Size(112, 29);
               this.textBox1.TabIndex = 26;
               this.textBox1.Text = "1000";
               // 
               // label4
               // 
               this.label4.AutoSize = true;
               this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label4.Location = new System.Drawing.Point(13, 185);
               this.label4.Name = "label4";
               this.label4.Size = new System.Drawing.Size(193, 26);
               this.label4.TabIndex = 23;
               this.label4.Text = "Output (Hash Value):";
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(848, 661);
               this.Controls.Add(this.lblState);
               this.Controls.Add(this.richText);
               this.Controls.Add(this.textBox1);
               this.Controls.Add(this.setSleepTime);
               this.Controls.Add(this.txtHashResult);
               this.Controls.Add(this.btnSimulationCalculation);
               this.Controls.Add(this.label4);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.txtMsg);
               this.Controls.Add(this.label3);
               this.Controls.Add(this.label1);
               this.Name = "Form1";
               this.Text = "Form1";
               this.Load += new System.EventHandler(this.Form1_Load);
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion
          private System.Windows.Forms.Label lblState;
          private System.Windows.Forms.RichTextBox richText;
          private System.Windows.Forms.TextBox txtHashResult;
          private System.Windows.Forms.Button btnSimulationCalculation;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.TextBox txtMsg;
          private System.Windows.Forms.Label label3;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.Button setSleepTime;
          private System.Windows.Forms.TextBox textBox1;
          private System.Windows.Forms.Label label4;
     }
}

