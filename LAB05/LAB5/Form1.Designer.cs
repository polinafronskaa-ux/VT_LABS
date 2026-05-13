namespace LAB5
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
            label1 = new Label();
            txtNumber1 = new TextBox();
            label2 = new Label();
            txtNumber2 = new TextBox();
            btnAdd = new Button();
            btnMul = new Button();
            btnSub = new Button();
            btnDiv = new Button();
            label3 = new Label();
            lblResult = new Label();
            btnClear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(192, 88);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Число 1";
            label1.Click += label1_Click;
            // 
            // txtNumber1
            // 
            txtNumber1.Location = new Point(267, 85);
            txtNumber1.Name = "txtNumber1";
            txtNumber1.Size = new Size(208, 23);
            txtNumber1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 125);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Число 2";
            label2.Click += label2_Click;
            // 
            // txtNumber2
            // 
            txtNumber2.Location = new Point(267, 117);
            txtNumber2.Name = "txtNumber2";
            txtNumber2.Size = new Size(208, 23);
            txtNumber2.TabIndex = 3;
            txtNumber2.TextChanged += txtNumber2_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(210, 156);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 30);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnMul
            // 
            btnMul.Location = new Point(362, 156);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(70, 30);
            btnMul.TabIndex = 5;
            btnMul.Text = "*";
            btnMul.UseVisualStyleBackColor = true;
            btnMul.Click += btnMul_Click;
            // 
            // btnSub
            // 
            btnSub.Cursor = Cursors.Cross;
            btnSub.Location = new Point(286, 156);
            btnSub.Name = "btnSub";
            btnSub.Size = new Size(70, 30);
            btnSub.TabIndex = 6;
            btnSub.Text = "\t-";
            btnSub.UseVisualStyleBackColor = true;
            btnSub.Click += btnSub_Click;
            // 
            // btnDiv
            // 
            btnDiv.Location = new Point(438, 156);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(70, 30);
            btnDiv.TabIndex = 8;
            btnDiv.Text = "\t/";
            btnDiv.UseVisualStyleBackColor = true;
            btnDiv.Click += btnDiv_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 253);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 9;
            label3.Text = "Результат";
            label3.Click += label3_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(328, 253);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 10;
            lblResult.Click += lblResult_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(310, 201);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 28);
            btnClear.TabIndex = 11;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(lblResult);
            Controls.Add(label3);
            Controls.Add(btnDiv);
            Controls.Add(btnSub);
            Controls.Add(btnMul);
            Controls.Add(btnAdd);
            Controls.Add(txtNumber2);
            Controls.Add(label2);
            Controls.Add(txtNumber1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Калькулятор V1.0";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNumber1;
        private Label label2;
        private TextBox txtNumber2;
        private Button btnAdd;
        private Button btnMul;
        private Button btnSub;
        private Button btnDiv;
        private Label label3;
        private Label lblResult;
        private Button btnClear;
    }
}
