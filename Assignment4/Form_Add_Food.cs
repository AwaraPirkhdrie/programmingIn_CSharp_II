using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal_Park
{
    public partial class Form_Add_Food : Form
    {
        public Food_Item fooditem = new Food_Item();
        private string Food_Item_Name;
        private string Ingredient_Name_and_Details;
        public Food_Item Fooditem
        {
            get { return this.fooditem; }
            
        }

        /// <summary>
        /// Checks user input for Food Menu add form
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {

            this.Food_Item_Name = TextBox_Name.Text.Trim();
            if (this.Food_Item_Name.Length == 0)
            {
                MessageBox.Show("Food Item Name should not be empty or blanks.");
                return false;
            }
            
            if (this.ListBox_Ingredients.Items == null)
            {
                MessageBox.Show("At least one ingredient must be provided.");
                return false;
            }


            return true;
        }
        public void Update_GUI()
        {

        }
        /// <summary>
        /// Adds a new food item
        /// </summary>
        public Form_Add_Food()
        {
            InitializeComponent();
            Food_Item_Name = "";
            Ingredient_Name_and_Details = "";

        }
        /// <summary>
        /// Adds a new food ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Ingredient_Name_and_Details = TextBox_Ingredient.Text.Trim();

            if (Ingredient_Name_and_Details.Length > 0)
            {
                fooditem.Ingredients.Add(Ingredient_Name_and_Details);
                ListBox_Ingredients.Items.Add(Ingredient_Name_and_Details);
                TextBox_Ingredient.Clear();
            }
            else
            {
                MessageBox.Show("Ingridient cannot be empty or blanks.");
            }
        }
        /// <summary>
        /// Changes a given ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Change_Click(object sender, EventArgs e)
        {
            if (this.ListBox_Ingredients.Items == null)
            {
                return;
            }

            int index = ListBox_Ingredients.SelectedIndex;
            string changed_ingredient = TextBox_Ingredient.Text.Trim();
            if(changed_ingredient.Length > 0)
            {
                ListBox_Ingredients.Items[index] = changed_ingredient;
                TextBox_Ingredient.Clear();
            }
        }
        /// <summary>
        /// Deletes given ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.ListBox_Ingredients.Items == null)
            {
                return;
            }
            int index = ListBox_Ingredients.SelectedIndex;
            if (index >= 0)
            {
                ListBox_Ingredients.Items.RemoveAt(index);
                TextBox_Ingredient.Clear();
            }
        }
        /// <summary>
        /// Submits a new food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OK_Click(object sender, EventArgs e)
        {
            if (this.TextBox_Name.Text.Trim().Length == 0)
            {
                MessageBox.Show("A food item must have a name.");
                return;
            }
            if (this.ListBox_Ingredients.Items == null)
            {
                MessageBox.Show("A food item must have at least 1 ingredient. Feed the animals!");
                return;
            }
            if (this.ListBox_Ingredients.Items.Count == 0)
            {
                MessageBox.Show("A food item must have at least 1 ingredient. Feed the animals!");
                return;
            }
            fooditem.Name = TextBox_Name.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// Cancels changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            if (this.ListBox_Ingredients.Items == null)
            {
                return;
            }
        }
        /// <summary>
        /// Choise of an ingredient to delete or change
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_Ingredients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ListBox_Ingredients.SelectedIndex;
            if (index >= 0)
            {
                TextBox_Ingredient.Text = ListBox_Ingredients.Items[index].ToString();
            }
            
        }
    }
}
