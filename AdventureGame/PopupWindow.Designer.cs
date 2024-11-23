namespace AdventureGame
{
    partial class PopupWindowModifier
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
            panel1 = new Panel();
            buttonEnterModifier = new Button();
            labelModifierInfo = new Label();
            textBoxModifierInput = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonEnterModifier);
            panel1.Controls.Add(labelModifierInfo);
            panel1.Controls.Add(textBoxModifierInput);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(531, 176);
            panel1.TabIndex = 0;
            // 
            // buttonEnterModifier
            // 
            buttonEnterModifier.Location = new Point(209, 99);
            buttonEnterModifier.Name = "buttonEnterModifier";
            buttonEnterModifier.Size = new Size(94, 29);
            buttonEnterModifier.TabIndex = 2;
            buttonEnterModifier.Text = "Enter";
            buttonEnterModifier.UseVisualStyleBackColor = true;
            buttonEnterModifier.Click += buttonEnterModifier_Click;
            // 
            // labelModifierInfo
            // 
            labelModifierInfo.AutoSize = true;
            labelModifierInfo.Location = new Point(125, 43);
            labelModifierInfo.Name = "labelModifierInfo";
            labelModifierInfo.Size = new Size(265, 20);
            labelModifierInfo.TabIndex = 1;
            labelModifierInfo.Text = "Enter your hard-earned modifiers here:";
            // 
            // textBoxModifierInput
            // 
            textBoxModifierInput.Location = new Point(128, 66);
            textBoxModifierInput.Name = "textBoxModifierInput";
            textBoxModifierInput.Size = new Size(262, 27);
            textBoxModifierInput.TabIndex = 0;
            textBoxModifierInput.Click += textBoxModifierInput_Click;
            // 
            // PopupWindowModifier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 176);
            Controls.Add(panel1);
            Name = "PopupWindowModifier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PopupWindow";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelModifierInfo;
        private Button buttonEnterModifier;
        public TextBox textBoxModifierInput;
    }
}