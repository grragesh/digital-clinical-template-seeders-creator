namespace ExcelToJson
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SectionNumber = new System.Windows.Forms.NumericUpDown();
            this.SectionNames = new System.Windows.Forms.NumericUpDown();
            this.exampleText = new System.Windows.Forms.NumericUpDown();
            this.boliertext = new System.Windows.Forms.NumericUpDown();
            this.instructionText = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.TemplateSections = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.sectionType = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.TemplateId = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.TemplateSectionId = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.OrgName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.boliertext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateSections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateSectionId)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(221, 270);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Convert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please Provide the order of the below Fields";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Section Numbers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Section Names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Instructional Text";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Boilerplate Text";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Example Text";
            // 
            // SectionNumber
            // 
            this.SectionNumber.Location = new System.Drawing.Point(125, 94);
            this.SectionNumber.Name = "SectionNumber";
            this.SectionNumber.Size = new System.Drawing.Size(46, 20);
            this.SectionNumber.TabIndex = 10;
            this.SectionNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SectionNames
            // 
            this.SectionNames.Location = new System.Drawing.Point(125, 119);
            this.SectionNames.Name = "SectionNames";
            this.SectionNames.Size = new System.Drawing.Size(46, 20);
            this.SectionNames.TabIndex = 11;
            this.SectionNames.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // exampleText
            // 
            this.exampleText.Location = new System.Drawing.Point(125, 217);
            this.exampleText.Name = "exampleText";
            this.exampleText.Size = new System.Drawing.Size(46, 20);
            this.exampleText.TabIndex = 13;
            this.exampleText.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // boliertext
            // 
            this.boliertext.Location = new System.Drawing.Point(125, 191);
            this.boliertext.Name = "boliertext";
            this.boliertext.Size = new System.Drawing.Size(46, 20);
            this.boliertext.TabIndex = 14;
            this.boliertext.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // instructionText
            // 
            this.instructionText.Location = new System.Drawing.Point(125, 168);
            this.instructionText.Name = "instructionText";
            this.instructionText.Size = new System.Drawing.Size(46, 20);
            this.instructionText.TabIndex = 15;
            this.instructionText.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(220, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(235, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "No. of  Sections in TemplateSection Seeder files";
            // 
            // TemplateSections
            // 
            this.TemplateSections.Location = new System.Drawing.Point(491, 94);
            this.TemplateSections.Name = "TemplateSections";
            this.TemplateSections.Size = new System.Drawing.Size(46, 20);
            this.TemplateSections.TabIndex = 18;
            this.TemplateSections.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "SectionType";
            // 
            // sectionType
            // 
            this.sectionType.Location = new System.Drawing.Point(124, 143);
            this.sectionType.Name = "sectionType";
            this.sectionType.Size = new System.Drawing.Size(46, 20);
            this.sectionType.TabIndex = 12;
            this.sectionType.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Template ID to be assigned";
            // 
            // TemplateId
            // 
            this.TemplateId.Location = new System.Drawing.Point(491, 123);
            this.TemplateId.Name = "TemplateId";
            this.TemplateId.Size = new System.Drawing.Size(46, 20);
            this.TemplateId.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(233, 150);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Beginning Template Section Id";
            // 
            // TemplateSectionId
            // 
            this.TemplateSectionId.Location = new System.Drawing.Point(491, 150);
            this.TemplateSectionId.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TemplateSectionId.Name = "TemplateSectionId";
            this.TemplateSectionId.Size = new System.Drawing.Size(46, 20);
            this.TemplateSectionId.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(220, 180);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Organisation Name to be Appended";
            // 
            // OrgName
            // 
            this.OrgName.Location = new System.Drawing.Point(427, 180);
            this.OrgName.Name = "OrgName";
            this.OrgName.Size = new System.Drawing.Size(152, 20);
            this.OrgName.TabIndex = 24;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 435);
            this.Controls.Add(this.OrgName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TemplateSectionId);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TemplateId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TemplateSections);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.instructionText);
            this.Controls.Add(this.boliertext);
            this.Controls.Add(this.exampleText);
            this.Controls.Add(this.sectionType);
            this.Controls.Add(this.SectionNames);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SectionNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.SectionNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exampleText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.boliertext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateSections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TemplateSectionId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown SectionNumber;
        private System.Windows.Forms.NumericUpDown SectionNames;
        private System.Windows.Forms.NumericUpDown exampleText;
        private System.Windows.Forms.NumericUpDown boliertext;
        private System.Windows.Forms.NumericUpDown instructionText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown TemplateSections;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown sectionType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown TemplateId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown TemplateSectionId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox OrgName;
    }
}

