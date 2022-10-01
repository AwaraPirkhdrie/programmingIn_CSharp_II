namespace Animal_Park
{
    partial class Form_Add_Food
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
            this.GrpBox_Add_Ing = new System.Windows.Forms.GroupBox();
            this.ListBox_Ingredients = new System.Windows.Forms.ListBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.Btn_Delete = new System.Windows.Forms.Button();
            this.Btn_Change = new System.Windows.Forms.Button();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.TextBox_Ingredient = new System.Windows.Forms.TextBox();
            this.Lbl_Ingredient = new System.Windows.Forms.Label();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.GrpBox_Add_Ing.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Add_Ing
            // 
            this.GrpBox_Add_Ing.Controls.Add(this.ListBox_Ingredients);
            this.GrpBox_Add_Ing.Controls.Add(this.Btn_Cancel);
            this.GrpBox_Add_Ing.Controls.Add(this.Btn_OK);
            this.GrpBox_Add_Ing.Controls.Add(this.Btn_Delete);
            this.GrpBox_Add_Ing.Controls.Add(this.Btn_Change);
            this.GrpBox_Add_Ing.Controls.Add(this.Btn_Add);
            this.GrpBox_Add_Ing.Controls.Add(this.TextBox_Ingredient);
            this.GrpBox_Add_Ing.Controls.Add(this.Lbl_Ingredient);
            this.GrpBox_Add_Ing.Location = new System.Drawing.Point(12, 92);
            this.GrpBox_Add_Ing.Name = "GrpBox_Add_Ing";
            this.GrpBox_Add_Ing.Size = new System.Drawing.Size(331, 325);
            this.GrpBox_Add_Ing.TabIndex = 0;
            this.GrpBox_Add_Ing.TabStop = false;
            this.GrpBox_Add_Ing.Text = "Add Ingredient";
            // 
            // ListBox_Ingredients
            // 
            this.ListBox_Ingredients.FormattingEnabled = true;
            this.ListBox_Ingredients.ItemHeight = 16;
            this.ListBox_Ingredients.Location = new System.Drawing.Point(102, 106);
            this.ListBox_Ingredients.Name = "ListBox_Ingredients";
            this.ListBox_Ingredients.Size = new System.Drawing.Size(209, 148);
            this.ListBox_Ingredients.TabIndex = 8;
            this.ListBox_Ingredients.SelectedIndexChanged += new System.EventHandler(this.ListBox_Ingredients_SelectedIndexChanged);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Cancel.Location = new System.Drawing.Point(236, 284);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.TabIndex = 7;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_OK
            // 
            this.Btn_OK.Location = new System.Drawing.Point(17, 284);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(75, 23);
            this.Btn_OK.TabIndex = 6;
            this.Btn_OK.Text = "OK";
            this.Btn_OK.UseVisualStyleBackColor = true;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Location = new System.Drawing.Point(17, 231);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.Btn_Delete.TabIndex = 4;
            this.Btn_Delete.Text = "Delete";
            this.Btn_Delete.UseVisualStyleBackColor = true;
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Change
            // 
            this.Btn_Change.Location = new System.Drawing.Point(17, 171);
            this.Btn_Change.Name = "Btn_Change";
            this.Btn_Change.Size = new System.Drawing.Size(75, 23);
            this.Btn_Change.TabIndex = 3;
            this.Btn_Change.Text = "Change";
            this.Btn_Change.UseVisualStyleBackColor = true;
            this.Btn_Change.Click += new System.EventHandler(this.Btn_Change_Click);
            // 
            // Btn_Add
            // 
            this.Btn_Add.Location = new System.Drawing.Point(17, 108);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(75, 23);
            this.Btn_Add.TabIndex = 2;
            this.Btn_Add.Text = "Add";
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // TextBox_Ingredient
            // 
            this.TextBox_Ingredient.Location = new System.Drawing.Point(102, 39);
            this.TextBox_Ingredient.Name = "TextBox_Ingredient";
            this.TextBox_Ingredient.Size = new System.Drawing.Size(209, 22);
            this.TextBox_Ingredient.TabIndex = 1;
            // 
            // Lbl_Ingredient
            // 
            this.Lbl_Ingredient.AutoSize = true;
            this.Lbl_Ingredient.Location = new System.Drawing.Point(14, 42);
            this.Lbl_Ingredient.Name = "Lbl_Ingredient";
            this.Lbl_Ingredient.Size = new System.Drawing.Size(71, 17);
            this.Lbl_Ingredient.TabIndex = 0;
            this.Lbl_Ingredient.Text = "Ingredient";
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.AutoSize = true;
            this.Lbl_Name.Location = new System.Drawing.Point(26, 41);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(45, 17);
            this.Lbl_Name.TabIndex = 1;
            this.Lbl_Name.Text = "Name";
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(114, 38);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(209, 22);
            this.TextBox_Name.TabIndex = 2;
            // 
            // Form_Add_Food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 429);
            this.Controls.Add(this.TextBox_Name);
            this.Controls.Add(this.Lbl_Name);
            this.Controls.Add(this.GrpBox_Add_Ing);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Add_Food";
            this.Text = "Form_Add_Food";
            this.GrpBox_Add_Ing.ResumeLayout(false);
            this.GrpBox_Add_Ing.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Add_Ing;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.TextBox TextBox_Ingredient;
        private System.Windows.Forms.Label Lbl_Ingredient;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Button Btn_Delete;
        private System.Windows.Forms.Button Btn_Change;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.ListBox ListBox_Ingredients;
    }
}