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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupWindowModifier));
            panelModifier = new Panel();
            buttonEnterModifier = new Button();
            textBoxModifierInput = new TextBox();
            panelModifier.SuspendLayout();
            SuspendLayout();
            // 
            // panelModifier
            // 
            panelModifier.BackgroundImage = Properties.Resources.modifierimage;
            panelModifier.BackgroundImageLayout = ImageLayout.Stretch;
            panelModifier.Controls.Add(buttonEnterModifier);
            panelModifier.Controls.Add(textBoxModifierInput);
            panelModifier.Dock = DockStyle.Fill;
            panelModifier.Location = new Point(0, 0);
            panelModifier.Name = "panelModifier";
            panelModifier.Size = new Size(531, 176);
            panelModifier.TabIndex = 0;
            // 
            // buttonEnterModifier
            // 
            buttonEnterModifier.Location = new Point(224, 102);
            buttonEnterModifier.Name = "buttonEnterModifier";
            buttonEnterModifier.Size = new Size(94, 29);
            buttonEnterModifier.TabIndex = 2;
            buttonEnterModifier.Text = "Enter";
            buttonEnterModifier.UseVisualStyleBackColor = true;
            buttonEnterModifier.Click += buttonEnterModifier_Click;
            // 
            // textBoxModifierInput
            // 
            textBoxModifierInput.Location = new Point(182, 57);
            textBoxModifierInput.Name = "textBoxModifierInput";
            textBoxModifierInput.Size = new Size(179, 27);
            textBoxModifierInput.TabIndex = 0;
            textBoxModifierInput.Text = "Enter your modifiers here";
            textBoxModifierInput.Click += textBoxModifierInput_Click;
            // 
            // PopupWindowModifier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 176);
            Controls.Add(panelModifier);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PopupWindowModifier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modifiers";
            panelModifier.ResumeLayout(false);
            panelModifier.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelModifier;
        private Button buttonEnterModifier;
        public TextBox textBoxModifierInput;
    }
}