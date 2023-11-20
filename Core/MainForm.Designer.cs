namespace Core
{
    partial class MainForm
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
            this.findAndLoadBtn = new System.Windows.Forms.Button();
            this.cityComboBox = new System.Windows.Forms.ComboBox();
            this.codesTreeView = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endWorkTimeLabel = new System.Windows.Forms.Label();
            this.startWorkTimeLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.difWorkTimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.companyNumberLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.hasPhoneCheckBox = new System.Windows.Forms.CheckBox();
            this.hasWebsiteCheckBox = new System.Windows.Forms.CheckBox();
            this.hasEmailCheckBox = new System.Windows.Forms.CheckBox();
            this.executionLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.codesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.addCodeBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // findAndLoadBtn
            // 
            this.findAndLoadBtn.Location = new System.Drawing.Point(13, 159);
            this.findAndLoadBtn.Name = "findAndLoadBtn";
            this.findAndLoadBtn.Size = new System.Drawing.Size(245, 35);
            this.findAndLoadBtn.TabIndex = 3;
            this.findAndLoadBtn.Text = "Найти и скачать";
            this.findAndLoadBtn.UseVisualStyleBackColor = true;
            this.findAndLoadBtn.Click += new System.EventHandler(this.findAndLoadBtn_Click);
            // 
            // cityComboBox
            // 
            this.cityComboBox.FormattingEnabled = true;
            this.cityComboBox.Items.AddRange(new object[] {
            "Москва",
            "Санкт-Петербург"});
            this.cityComboBox.Location = new System.Drawing.Point(13, 15);
            this.cityComboBox.Name = "cityComboBox";
            this.cityComboBox.Size = new System.Drawing.Size(245, 27);
            this.cityComboBox.TabIndex = 1;
            this.cityComboBox.Text = "выберите город...";
            // 
            // codesTreeView
            // 
            this.codesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codesTreeView.Location = new System.Drawing.Point(281, 257);
            this.codesTreeView.Name = "codesTreeView";
            this.codesTreeView.Size = new System.Drawing.Size(709, 588);
            this.codesTreeView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Начало работы:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Завершение работы:";
            // 
            // endWorkTimeLabel
            // 
            this.endWorkTimeLabel.Location = new System.Drawing.Point(168, 46);
            this.endWorkTimeLabel.Name = "endWorkTimeLabel";
            this.endWorkTimeLabel.Size = new System.Drawing.Size(90, 20);
            this.endWorkTimeLabel.TabIndex = 6;
            this.endWorkTimeLabel.Text = "...";
            // 
            // startWorkTimeLabel
            // 
            this.startWorkTimeLabel.Location = new System.Drawing.Point(168, 13);
            this.startWorkTimeLabel.Name = "startWorkTimeLabel";
            this.startWorkTimeLabel.Size = new System.Drawing.Size(90, 20);
            this.startWorkTimeLabel.TabIndex = 6;
            this.startWorkTimeLabel.Text = "...";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Общее время работы:";
            // 
            // difWorkTimeLabel
            // 
            this.difWorkTimeLabel.Location = new System.Drawing.Point(168, 76);
            this.difWorkTimeLabel.Name = "difWorkTimeLabel";
            this.difWorkTimeLabel.Size = new System.Drawing.Size(87, 20);
            this.difWorkTimeLabel.TabIndex = 6;
            this.difWorkTimeLabel.Text = "...";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Количество компаний:";
            // 
            // companyNumberLabel
            // 
            this.companyNumberLabel.Location = new System.Drawing.Point(168, 136);
            this.companyNumberLabel.Name = "companyNumberLabel";
            this.companyNumberLabel.Size = new System.Drawing.Size(87, 20);
            this.companyNumberLabel.TabIndex = 6;
            this.companyNumberLabel.Text = "...";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Просмотрено страниц:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(168, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "...";
            // 
            // hasPhoneCheckBox
            // 
            this.hasPhoneCheckBox.AutoSize = true;
            this.hasPhoneCheckBox.Location = new System.Drawing.Point(13, 58);
            this.hasPhoneCheckBox.Name = "hasPhoneCheckBox";
            this.hasPhoneCheckBox.Size = new System.Drawing.Size(109, 23);
            this.hasPhoneCheckBox.TabIndex = 7;
            this.hasPhoneCheckBox.Text = "с телефоном";
            this.hasPhoneCheckBox.UseVisualStyleBackColor = true;
            // 
            // hasWebsiteCheckBox
            // 
            this.hasWebsiteCheckBox.AutoSize = true;
            this.hasWebsiteCheckBox.Location = new System.Drawing.Point(13, 87);
            this.hasWebsiteCheckBox.Name = "hasWebsiteCheckBox";
            this.hasWebsiteCheckBox.Size = new System.Drawing.Size(83, 23);
            this.hasWebsiteCheckBox.TabIndex = 7;
            this.hasWebsiteCheckBox.Text = "с сайтом";
            this.hasWebsiteCheckBox.UseVisualStyleBackColor = true;
            // 
            // hasEmailCheckBox
            // 
            this.hasEmailCheckBox.AutoSize = true;
            this.hasEmailCheckBox.Location = new System.Drawing.Point(13, 116);
            this.hasEmailCheckBox.Name = "hasEmailCheckBox";
            this.hasEmailCheckBox.Size = new System.Drawing.Size(76, 23);
            this.hasEmailCheckBox.TabIndex = 7;
            this.hasEmailCheckBox.Text = "с e-mail";
            this.hasEmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // executionLabel
            // 
            this.executionLabel.Location = new System.Drawing.Point(13, 302);
            this.executionLabel.Name = "executionLabel";
            this.executionLabel.Size = new System.Drawing.Size(155, 20);
            this.executionLabel.TabIndex = 6;
            this.executionLabel.Text = "Жду запуск";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cityComboBox);
            this.panel1.Controls.Add(this.hasPhoneCheckBox);
            this.panel1.Controls.Add(this.hasWebsiteCheckBox);
            this.panel1.Controls.Add(this.hasEmailCheckBox);
            this.panel1.Controls.Add(this.findAndLoadBtn);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 212);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.startWorkTimeLabel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.companyNumberLabel);
            this.panel2.Controls.Add(this.executionLabel);
            this.panel2.Controls.Add(this.difWorkTimeLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.endWorkTimeLabel);
            this.panel2.Location = new System.Drawing.Point(3, 257);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 338);
            this.panel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.codesRichTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.addCodeBtn, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(281, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.81102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.1496F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.86614F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.35433F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(709, 248);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // codesRichTextBox
            // 
            this.codesRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codesRichTextBox.Location = new System.Drawing.Point(3, 31);
            this.codesRichTextBox.Name = "codesRichTextBox";
            this.codesRichTextBox.ReadOnly = true;
            this.codesRichTextBox.Size = new System.Drawing.Size(703, 124);
            this.codesRichTextBox.TabIndex = 8;
            this.codesRichTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Вид деятельности (ОКВЭД 2)";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Можно добавить несколько кодов";
            // 
            // addCodeBtn
            // 
            this.addCodeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addCodeBtn.Location = new System.Drawing.Point(276, 166);
            this.addCodeBtn.Name = "addCodeBtn";
            this.addCodeBtn.Size = new System.Drawing.Size(157, 34);
            this.addCodeBtn.TabIndex = 9;
            this.addCodeBtn.Text = "Добавить код";
            this.addCodeBtn.UseVisualStyleBackColor = true;
            this.addCodeBtn.Click += new System.EventHandler(this.addCodeBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tableLayoutPanel2.Controls.Add(this.codesTreeView, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(993, 848);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(993, 848);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Скачивание информации о компаниях из интернета  источник - https://www.list-org.c" +
    "om";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button findAndLoadBtn;
        private ComboBox cityComboBox;
        private TreeView codesTreeView;
        private Label label1;
        private Label label3;
        private Label endWorkTimeLabel;
        private Label startWorkTimeLabel;
        private Label label6;
        private Label difWorkTimeLabel;
        private Label label4;
        private Label companyNumberLabel;
        private Label label5;
        private Label label7;
        private CheckBox hasPhoneCheckBox;
        private CheckBox hasWebsiteCheckBox;
        private CheckBox hasEmailCheckBox;
        private Label executionLabel;
        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox codesRichTextBox;
        private Label label2;
        private Label label8;
        private Button addCodeBtn;
        private TableLayoutPanel tableLayoutPanel2;
    }
}