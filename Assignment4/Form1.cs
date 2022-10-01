using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal_Park
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initialized the main form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Initialize_GUI(0);
        }

        List<uint>  Ids = new List<uint>();
        Animal_handler Animal_editor = new Animal_handler();
        AnimalManager Animal_manager = new AnimalManager();
        FoodManager Food_manager = new FoodManager();

        bool Animal_manager_saved = true;
        bool Food_manager_saved = true;
        string Animal_manager_file_path = "";
        string Food_manager_file_path = "";

        /// <summary>
        /// Initializes GUI controls
        /// </summary>
        private void Initialize_GUI(int i_key)
        {
            if ((i_key == 1 )|(i_key == 0))
            {
                ListBox_Gender.DataSource = Enum.GetValues(typeof(GenderType));
                ListBox_CategoryType.DataSource = Enum.GetValues(typeof(CategoryType));

                ListBox_Gender.SelectedIndex = 0;
                ListBox_CategoryType.SelectedIndex = 0;

                ListView_Animals.View = View.Details;

                ListBoxFoodItem.Items.Clear();

                Lbl_animal_info.Text = "Animal info: ";
                ListView_Animals.Items.Clear();
            }
            
            if ((i_key == 2)|(i_key == 0))
            {
                ListBox_Food.Items.Clear();
            } 

        }
        /// <summary>
        /// Retrives selected Animal Category
        /// </summary>
        /// <returns></returns>
        private CategoryType GetSelectedCategory()
        {
            CategoryType category;

            if (ListBox_CategoryType.SelectedIndex >= 0)
            {
                category = (CategoryType)ListBox_CategoryType.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Animal category should be given.");
                category = CategoryType.Bird;
            }

            return category;
        }
        /// <summary>
        /// Switch to update GUI accoring to animal type choise
        /// </summary>
        /// <param name="category"></param>
        private void Update_GUI_by_Category(CategoryType category)
        {
            switch (category)
            {
                case CategoryType.Bird:
                    Update_GUI_Bird();
                    break;
                case CategoryType.Fish:
                    Update_GUI_Fish();
                    break;
                case CategoryType.Insect:
                    Update_GUI_Insect();
                    break;
                case CategoryType.Mammal:
                    Update_GUI_Mammal();
                    break;
                case CategoryType.Reptile:
                    Update_GUI_Reptile();
                    break;
            }
            if (!CheckBox_List_Animals.Checked)
            {
                ListBox_AnimalObj.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// Updates GUI for Bird type
        /// </summary>
        private void Update_GUI_Bird()
        {
            if (!CheckBox_List_Animals.Checked)
            {
                ListBox_AnimalObj.DataSource = Enum.GetValues(typeof(Bird_list));
            }
            label5.Text = "Max speed [km/h]";
            label6.Text = "Habitat";
            label7.Text = "";
            TextBox_Spec1.Enabled = true;
            TextBox_Spec1.Text = "";
            TextBox_Spec2.Enabled = true;
            TextBox_Spec2.Text = "";
            TextBox_Spec3.Enabled = false;
            TextBox_Spec3.Text = "";
            TextBox_Spec1.Visible = true;
            TextBox_Spec2.Visible = true;
            TextBox_Spec3.Visible = false;
            CheckBox_Poison.Visible = false;
  
        }
        /// <summary>
        /// Updates GUI for Fish type
        /// </summary>
        private void Update_GUI_Fish()
        {
            if (!CheckBox_List_Animals.Checked)
            {
                ListBox_AnimalObj.DataSource = Enum.GetValues(typeof(Fish_list));
            }
            label5.Text = "Max speed [km/h]";
            label6.Text = "Max depth [m]";
            label7.Text = "";
            TextBox_Spec1.Enabled = true;
            TextBox_Spec1.Text = "";
            TextBox_Spec2.Enabled = true;
            TextBox_Spec2.Text = "";
            TextBox_Spec3.Enabled = false;
            TextBox_Spec3.Text = "";
            TextBox_Spec1.Visible = true;
            TextBox_Spec2.Visible = true;
            TextBox_Spec3.Visible = false;
            CheckBox_Poison.Visible = false;
        }
        /// <summary>
        /// Updates GUI for Insect type
        /// </summary>
        private void Update_GUI_Insect()
        {
            if (!CheckBox_List_Animals.Checked)
            {
                ListBox_AnimalObj.DataSource = Enum.GetValues(typeof(Insect_list));
            }
            
            label5.Text = "Habitat";
            label6.Text = "Number of legs";
            label7.Text = "Number of wings";
            TextBox_Spec1.Enabled = true;
            TextBox_Spec1.Text = "";
            TextBox_Spec2.Enabled = true;
            TextBox_Spec2.Text = "";
            TextBox_Spec3.Enabled = true;
            TextBox_Spec3.Text = "";
            TextBox_Spec1.Visible = true;
            TextBox_Spec2.Visible = true;
            TextBox_Spec3.Visible = true;
            CheckBox_Poison.Visible = false;
        }
        /// <summary>
        /// Updates GUI for Mammal type
        /// </summary>
        private void Update_GUI_Mammal()
        {
            if (!CheckBox_List_Animals.Checked)
            {
                ListBox_AnimalObj.DataSource = Enum.GetValues(typeof(Mammal_list));
            }
            
            label5.Text = "Tail Length [cm]";
            label6.Text = "Color";
            label7.Text = "";
            TextBox_Spec1.Enabled = true;
            TextBox_Spec1.Text = "";
            TextBox_Spec1.Visible = true;
            TextBox_Spec2.Enabled = true;
            TextBox_Spec2.Text = "";
            TextBox_Spec2.Visible = true;
            TextBox_Spec3.Enabled = false;
            TextBox_Spec3.Text = "";
            TextBox_Spec3.Visible = false;
            CheckBox_Poison.Visible = false;

        }
        /// <summary>
        /// Updates GUI for Reptile type
        /// </summary>
        private void Update_GUI_Reptile()
        {
            if (!CheckBox_List_Animals.Checked)
            {
                ListBox_AnimalObj.DataSource = Enum.GetValues(typeof(Reptile_list));
            }
            
            label5.Text = "Number of legs ";
            label6.Text = "Poison bite";
            label7.Text = "";
            TextBox_Spec1.Enabled = true;
            TextBox_Spec1.Text = "";
            TextBox_Spec2.Enabled = false;
            TextBox_Spec2.Text = "";
            TextBox_Spec3.Enabled = false;
            TextBox_Spec3.Text = "";
            TextBox_Spec1.Visible = true;
            TextBox_Spec2.Visible = false;
            TextBox_Spec3.Visible = false;
            CheckBox_Poison.Visible = true;
            CheckBox_Poison.Checked = false;

        }
        /// <summary>
        /// Updates GUI by chosen Animal Species
        /// </summary>
        /// <param name="animal_type"></param>
        private void GUI_by_animal_type(string animal_type)
        {
            switch (animal_type)
            {
                case "Raven":
                    label8.Text = "Number of claws : ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Owl":
                    label8.Text = "Pray: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Salmon":
                    label8.Text = "Origin: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Shark":
                    label8.Text = "Color: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Ant":
                    label8.Text = "Max life span: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Butterfly":
                    label8.Text = "Wing beat freq.: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Cat":
                    label8.Text = "Is Fluffy: ";
                    TextBox_species_1.Enabled = false;
                    TextBox_species_1.Visible = false;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Enabled = true;
                    RadioBtn_Animal_spec_1.Visible = true;
                    RadioBtn_Animal_spec_1.Checked = false;
                    break;
                case "Dog":
                    label8.Text = "Breed: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Horse":
                    label8.Text = "Max Speed: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Crocodile":
                    label8.Text = "Total length: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Snake":
                    label8.Text = "Snake family: ";
                    TextBox_species_1.Visible = true;
                    TextBox_species_1.Enabled = true;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = false;
                    RadioBtn_Animal_spec_1.Enabled = false;
                    break;
                case "Turtle":
                    label8.Text = "Can swim: ";
                    TextBox_species_1.Enabled = false;
                    TextBox_species_1.Visible = false;
                    TextBox_species_1.Text = "";
                    RadioBtn_Animal_spec_1.Visible = true;
                    RadioBtn_Animal_spec_1.Enabled = true;
                    RadioBtn_Animal_spec_1.Checked = false;
                    break;
            }
        }

        /// <summary>
        /// Mediator program for update GUI by Animal Species
        /// </summary>
        private void Update_GUI_by_Animal_Type()
        {
            String Animal_type = ListBox_AnimalObj.SelectedItem.ToString();

            TextBox_species_1.Text = "";
            RadioBtn_Animal_spec_1.Checked = false;
            GUI_by_animal_type(Animal_type);

        }
        /// <summary>
        /// Reads GUI input and creates an animal by calling corresponding method
        /// </summary>
        /// <returns></returns>
        private Animal Read_input_and_create_animal()
        {
            CategoryType Animal_category ;

            if (CheckBox_List_Animals.Checked)
            {
                Animal_category = Get_Category_all_species_listed();
            }
            else
            {
                Animal_category = GetSelectedCategory();
            }

            Animal new_animal = null;

            switch (Animal_category)
            {
                case CategoryType.Bird:
                    new_animal = CreateNewBird();
                    break;
                case CategoryType.Fish:
                    new_animal = CreateNewFish();
                    break;
                case CategoryType.Insect:
                    new_animal = CreateNewInsect();
                    break;
                case CategoryType.Mammal:
                    new_animal = CreateNewMammal();
                    break;
                case CategoryType.Reptile:
                    new_animal = CreateNewReptile();
                    break;
                default:
                    return null;
            }
            
            return new_animal;
        }
        /// <summary>
        /// Creates new Bird
        /// </summary>
        /// <returns></returns>
        private Animal CreateNewBird()
        {
            Animal new_animal = null;
            UInt32 maxspeed;
            String habitat;

            if(!UInt32.TryParse(TextBox_Spec1.Text, out maxspeed)){
                MessageBox.Show("Bird max speed should be given as IUnt32.");
                return new_animal;
            }
            habitat = TextBox_Spec2.Text;
            if (habitat.Length == 0)
            {
                MessageBox.Show("Habitat should be given as String.");
                return null;
            }

            Bird_list bird_type = (Bird_list)Enum.Parse(typeof(Bird_list), ListBox_AnimalObj.Text);

            new_animal = Animal_editor.Create_bird(bird_type, maxspeed, habitat);

            if (bird_type == Bird_list.Raven)
            {
                UInt32 N_claws;
                if (!UInt32.TryParse(TextBox_species_1.Text, out N_claws))
                {
                    MessageBox.Show("Number of claws should be given as IUnt32.");
                    return null;
                }
                else
                {
                   ((Raven)new_animal).n_claws = N_claws;
                }
                
            }
            else if (bird_type == Bird_list.Owl)
            {
                ((Owl)new_animal).pray = TextBox_species_1.Text;
            }
            
            return new_animal;
        }
        /// <summary>
        /// Creates new Fish
        /// </summary>
        /// <returns></returns>
        private Animal CreateNewFish()
        {
            Animal new_animal = null;
            UInt32 maxspeed;
            UInt32 maxdepth;

            if (!UInt32.TryParse(TextBox_Spec1.Text, out maxspeed))
            {
                MessageBox.Show("Fish max speed should be given as IUnt32.");
                return new_animal;
            }
            if (!UInt32.TryParse(TextBox_Spec2.Text, out maxdepth))
            {
                MessageBox.Show("Fish max depth should be given as IUnt32.");
                return new_animal;
            }

            Fish_list fish_type = (Fish_list)Enum.Parse(typeof(Fish_list), ListBox_AnimalObj.Text);

            new_animal = Animal_editor.Create_fish(fish_type, maxspeed, maxdepth);
            

            if (fish_type == Fish_list.Salmon)
            {
                ((Salmon)new_animal).origin = TextBox_species_1.Text;

            }
            else if (fish_type == Fish_list.Shark)
            {
                ((Shark)new_animal).color = TextBox_species_1.Text;
            }

            return new_animal;
        }
        /// <summary>
        /// Creates new Insect
        /// </summary>
        /// <returns></returns>
        private Animal CreateNewInsect()
        {
            Animal new_animal = null;
            String habitat;
            UInt32 n_legs = 0;
            UInt32 n_wings = 0;

            habitat = TextBox_Spec1.Text;
            if (habitat.Length == 0)
            {
                MessageBox.Show("Habitat should be given as String.");
                return null;
            }

            if (!UInt32.TryParse(TextBox_Spec2.Text, out n_legs))
            {
                MessageBox.Show("Number of legs should be given as IUnt32.");
                return null;
            }
            if (!UInt32.TryParse(TextBox_Spec3.Text, out n_wings))
            {
                MessageBox.Show("Number of wings should be given as IUnt32.");
                return null;
            }

            Insect_list insect_type = (Insect_list)Enum.Parse(typeof(Insect_list), ListBox_AnimalObj.Text);

            new_animal = Animal_editor.Create_insect(insect_type, habitat, n_legs, n_wings);

            if (insect_type == Insect_list.Ant)
            {
                UInt32 Max_life_span;
                if (!UInt32.TryParse(TextBox_species_1.Text, out Max_life_span))
                {
                    MessageBox.Show("Max life span should be given as IUnt32.");
                    return null; 
                }
                else
                {
                    ((Ant)new_animal).maxlifespan = Max_life_span;  
                }

            }
            else if (insect_type == Insect_list.Butterfly)
            {
                UInt32 Wingbeat_frequency;
                if (!UInt32.TryParse(TextBox_species_1.Text, out Wingbeat_frequency))
                {
                    MessageBox.Show("Wingbeat frequency should be given as IUnt32.");
                    return null;
                }
                else
                {
                    ((Butterfly)new_animal).wingbeat_frequency = Wingbeat_frequency;
                }

            }
            return new_animal;
        }
        /// <summary>
        /// Creates new Mammal
        /// </summary>
        /// <returns></returns>
        private Animal CreateNewMammal()
        {
            Animal new_animal = null;
            UInt32 taillength = 0;
            String Color;

            Color = TextBox_Spec2.Text;
            if (Color.Length == 0)
            {
                MessageBox.Show("Mammal color should be given as String.");
                return null;
            }

            if (!UInt32.TryParse(TextBox_Spec1.Text, out taillength))
            {
                MessageBox.Show("Taillength should be given as IUnt32.");
                return null;
            }
  
            Mammal_list mammal_type = (Mammal_list)Enum.Parse(typeof(Mammal_list), ListBox_AnimalObj.Text);

            new_animal = Animal_editor.Create_mammal(mammal_type, taillength, Color);
            
            if (mammal_type == Mammal_list.Cat)
            {
                ((Cat)new_animal).fluffy = RadioBtn_Animal_spec_1.Checked;
            }
            else if (mammal_type == Mammal_list.Dog)
            {
                ((Dog)new_animal).breed = TextBox_species_1.Text;
            }
            else if (mammal_type == Mammal_list.Horse)
            {
                UInt32 Maxspeed;
                if (!UInt32.TryParse(TextBox_species_1.Text, out Maxspeed))
                {
                    MessageBox.Show("Maxspeed should be given as IUnt32.");
                    return null;
                }
                else
                {
                    ((Horse)new_animal).maxspeed = Maxspeed;
                }
            }
            return new_animal;
        }
        /// <summary>
        /// Creates new Reptile
        /// </summary>
        /// <returns></returns>
        private Animal CreateNewReptile()
        {
            Animal new_animal = null;
            UInt32 N_legs;
            Boolean Bite;

            if (!UInt32.TryParse(TextBox_Spec1.Text, out N_legs))
            {
                MessageBox.Show("Number of legs should be given as IUnt32.");
                return null;
            }
            Bite = CheckBox_Poison.Checked;

            Reptile_list reptile_type = (Reptile_list)Enum.Parse(typeof(Reptile_list), ListBox_AnimalObj.Text);

            new_animal = Animal_editor.Create_reptile(reptile_type, N_legs, Bite);
            
            if (reptile_type == Reptile_list.Crocodile)
            {
                UInt32 Total_length;
                if (!UInt32.TryParse(TextBox_species_1.Text, out Total_length))
                {
                    MessageBox.Show("Total length should be given as IUnt32.");
                    return null;
                }
                else
                {
                    ((Crocodile)new_animal).total_length = Total_length;
                }
            }
            else if (reptile_type == Reptile_list.Snake)
            {
                ((Snake)new_animal).snake_family = TextBox_species_1.Text;
            }
            else if (reptile_type == Reptile_list.Turtle)
            {
                ((Turtle)new_animal).can_swim = RadioBtn_Animal_spec_1.Checked;
            }
            return new_animal;
        }

        /// <summary>
        /// Loads the main form and updated initial GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize_GUI(0);

        }
        /// <summary>
        /// Checks if User input of the animal properties is correct
        /// </summary>
        /// <returns></returns>
        private bool IsInputCorrect()
        {
            bool correct_input = true;

            String Name = Text_Box_Name_Input.Text.Trim();
            if (Name.Length <= 0)
            {
                MessageBox.Show("Animal name should be given.");
                return false;
            }
            UInt32 Age;
            if (!UInt32.TryParse(Text_Box_Age_Input.Text, out Age))
            {
                MessageBox.Show("Animal age should be given as UInt32.");
                return false;
            }
            UInt32 Weight;
            if (!UInt32.TryParse(Text_Box_Weight_Input.Text, out Weight))
            {
                MessageBox.Show("Animal weight should be given as UInt32.");
                return false;
            }
            String Behaviour = Text_Box_Behaviour_Input.Text.Trim();
            if (Behaviour.Length <= 0)
            {
                MessageBox.Show("Animal behaviour should be given.");
                return false;
            }

            GenderType Gender;
            if (ListBox_Gender.SelectedIndex >= 0)
            {
                Gender = (GenderType)ListBox_Gender.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Animal gender should be given.");
                Gender = GenderType.Unknown;
                return false;
            }
            CategoryType Category;

            if (CheckBox_List_Animals.Checked)
            {
                Category = Get_Category_all_species_listed();
            }
            else
            {
                if (ListBox_CategoryType.SelectedIndex >= 0)
                {
                    Category = (CategoryType)ListBox_CategoryType.SelectedIndex;
                }
                else
                {
                    MessageBox.Show("Animal category should be given.");
                    Category = CategoryType.Bird;
                    return false;
                }
            }

            return correct_input;
        }

        /// <summary>
        /// 
        ///  Adds an animal to the existing Animal list
        ///  if the input was correct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            bool correct_input = IsInputCorrect();
            Animal new_an = null;

            if (correct_input)
            {
                new_an = Read_input_and_create_animal();

                if (new_an != null)
                {
                    int N_animals = Ids.Count;

                    new_an.name = Text_Box_Name_Input.Text.Trim();
                    UInt32 anim_age;
                    UInt32.TryParse(Text_Box_Age_Input.Text, out anim_age);
                    new_an.age = anim_age;
                    UInt32 anim_weight;
                    UInt32.TryParse(Text_Box_Weight_Input.Text, out anim_weight);
                    new_an.weight = anim_weight;
                    new_an.behavior = Text_Box_Behaviour_Input.Text.Trim();
                    new_an.gender = (GenderType)ListBox_Gender.SelectedIndex;
                    new_an.category = (CategoryType)ListBox_CategoryType.SelectedIndex;
                    if (Ids.Count > 0)
                    {
                        new_an.id = (UInt32)Ids.Max() + 1;
                    }
                    else
                    {
                        new_an.id = 0;
                    }

                    string test = new_an.GetType().Name;

                    Animal_manager.Add(new_an);
                    Animal_manager_saved = false;
                    Ids.Add(new_an.id);

                    Text_Box_Name_Input.Text = "";
                    Text_Box_Age_Input.Text = "";
                    Text_Box_Weight_Input.Text = "";
                    Text_Box_Behaviour_Input.Text = "";

                    String info = new_an.ToString().Replace(";", ";\n");
                    info = info.Replace("*", " ");

                    String animal_type = new_an.GetType().Name;

                    Lbl_animal_info.Text = "Animal info: " + "\n" + " " + animal_type + "\n"+ info;
                    

                    string[] row1 = { new_an.name.ToString(), new_an.age.ToString(), new_an.gender.ToString(), new_an.GetExtraInfo() };

                    ListView_Animals.Sorting = System.Windows.Forms.SortOrder.None;

                    ListView_Animals.Items.Add(new_an.id.ToString());
                    ListView_Animals.Items[ListView_Animals.Items.Count - 1].SubItems.AddRange(row1);
                    
                    ListView_Animals.Items[ListView_Animals.Items.Count - 1].Focused = true;
                    ListView_Animals.Items[ListView_Animals.Items.Count - 1].Selected = true;

                    pictureBox1.Image = null;
                    Label_Photo.Visible = true;

                    Update_GUI_by_Category(new_an.category);
                    Update_GUI_by_Animal_Type();

                    ListView_Animals_SelectedIndexChanged_update_GUI();
                }
            }

        }
        /// <summary>
        /// Load photo by clicking the label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Label_Photo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();

            dia.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

            dia.FilterIndex = 1;
            dia.Multiselect = true;

            if (dia.ShowDialog() == DialogResult.OK)
            {
                Label_Photo.Visible = false;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                string sFileName = dia.FileName;
                pictureBox1.Image = Image.FromFile(sFileName);
            }

        }
        /// <summary>
        /// Updates GUI depending on chosen Animal Category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_CategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox_CategoryType.SelectedIndex < 0) return;
            CategoryType category = GetSelectedCategory();
            Update_GUI_by_Category(category);
        }
        /// <summary>
        /// Changed GUI and logic to add new animal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_List_Animals_CheckedChanged(object sender, EventArgs e)
        {
            ListBox_CategoryType.Enabled = !ListBox_CategoryType.Enabled;
            
            if (CheckBox_List_Animals.Checked)
            {
                var All_species_names = new List<Enum>();

                All_species_names.AddRange(Enum.GetValues(typeof(Bird_list)).Cast<Enum>());
                All_species_names.AddRange(Enum.GetValues(typeof(Fish_list)).Cast<Enum>());
                All_species_names.AddRange(Enum.GetValues(typeof(Insect_list)).Cast<Enum>());
                All_species_names.AddRange(Enum.GetValues(typeof(Mammal_list)).Cast<Enum>());
                All_species_names.AddRange(Enum.GetValues(typeof(Reptile_list)).Cast<Enum>());

                ListBox_AnimalObj.DataSource = All_species_names;
            }
            else
            {
                CategoryType Category;
                if (ListBox_CategoryType.SelectedIndex >= 0)
                {
                    Category = (CategoryType)ListBox_CategoryType.SelectedIndex;
                    Update_GUI_by_Category(Category);
                    Update_GUI_by_Animal_Type();
                }
                else
                {
                    MessageBox.Show("Animal category should be given.");
                    Category = CategoryType.Bird;
                    Update_GUI_by_Category(Category);
                    Update_GUI_by_Animal_Type();
                }

            }

        }
        /// <summary>
        /// To get category when checkbox "All animals" checked
        /// </summary>
        /// <returns></returns>
        private CategoryType Get_Category_all_species_listed()
        {
            CategoryType Category = CategoryType.Bird;
            String Animal_str;
            String Animal_type = ListBox_AnimalObj.SelectedItem.ToString();

            if (Enum.IsDefined(typeof(Bird_list), Animal_type))
            {
                Animal_str = "Bird";
            }
            else if (Enum.IsDefined(typeof(Fish_list), Animal_type))
            {
                Animal_str = "Fish";
            }
            else if (Enum.IsDefined(typeof(Insect_list), Animal_type))
            {
                Animal_str = "Insect";
            }
            else if (Enum.IsDefined(typeof(Mammal_list), Animal_type))
            {
                Animal_str = "Mammal";
            }
            else if (Enum.IsDefined(typeof(Reptile_list), Animal_type))
            {
                Animal_str = "Reptile";
            }
            else
            {
                MessageBox.Show("Unknown animal...");
                return Category;
            }

            Category = (CategoryType)Enum.Parse(typeof(CategoryType), Animal_str);
            return Category;
        }

        

        /// <summary>
        /// Update GUI according to the selected item in the Animal Species ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_AnimalObj_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox_Spec1.Text = "";
            TextBox_Spec2.Text = "";
            TextBox_Spec3.Text = "";
            CheckBox_Poison.Checked = false;

            if (CheckBox_List_Animals.Checked)
            {
                String Animal_type = ListBox_AnimalObj.SelectedItem.ToString();
                CategoryType Category = Get_Category_all_species_listed();
                Update_GUI_by_Category(Category);
                Update_GUI_by_Animal_Type();
            }
            else
            {
                Update_GUI_by_Animal_Type();
            }

            Text_Box_Name_Input.Text = "";
            Text_Box_Age_Input.Text = "";
            Text_Box_Weight_Input.Text = "";
            Text_Box_Behaviour_Input.Text = "";
        }
        /// <summary>
        ///  The routine which updates GUI when the selected index in the Animals List
        ///  Box is changed
        /// </summary>
        void ListView_Animals_SelectedIndexChanged_update_GUI()
        {
            if (ListView_Animals.FocusedItem == null)
            {
                return;
            }

            int index = ListView_Animals.FocusedItem.Index;

            if (index == -1)
            {
                return;
            }

            Animal animal = Animal_manager.GetAt(index);

            FoodSchedule foodSchedule = animal.GetFoodSchedule();

            ListBox_Food.Items.Clear();
            ListBox_Food.Items.Add(foodSchedule.Title());

            Lbl_Eater.Text = "Eater Type: " + foodSchedule.EaterType.ToString();

            ListBox_Food.Items.Clear();
            int food_index = Animal_manager.FoodItemConnected((int)Animal_manager.GetAt(index).id);
            if (food_index >= 0)
            {
                //string[] new_food_info = Food_manager.foodItemList[food_index].ToStringArray();
                string[] new_food_info = Food_manager.GetAt(food_index).ToStringArray();
                ListBox_Food.Items.AddRange(new_food_info);
            }
            else
            {
                string[] foodList = foodSchedule.GetFoodListInfoStrings();
                ListBox_Food.Items.AddRange(foodList);
            }

            String info = animal.ToString().Replace(";", ";\n");
            info = info.Replace("*", " ");
            String animal_type = animal.GetType().Name;

            Lbl_animal_info.Text = "Animal info: " + "\n" + "Animal type: " + animal_type + "\n" + info;

            String Animal_type = animal.GetType().Name;

            int index_cat = ListBox_CategoryType.Items.IndexOf(animal.category);
            ListBox_CategoryType.SelectedIndex = index_cat;

            Update_GUI_by_Category(animal.category);

            Lbl_animal_info.Text = "Animal info: " + "\n" + "Animal type: " + animal_type + "\n" + info;


            String anim_gender = animal.AnimGender.ToString();

            ListBox_Gender.SelectedIndex = (int)Enum.Parse(typeof(GenderType), anim_gender);

            string[] anim_info = animal.ToString().Split(';');

            string str1;

            switch (animal.category.ToString())
            {
                case "Bird":
                    ListBox_AnimalObj.SelectedIndex = (int)Enum.Parse(typeof(Bird_list), Animal_type);

                    TextBox_Spec1.Text = anim_info[7].Substring(anim_info[7].LastIndexOf('*') + 1).Trim();
                    TextBox_Spec2.Text = anim_info[8].Substring(anim_info[8].LastIndexOf('*') + 1).Trim();

                    if (ListBox_AnimalObj.SelectedIndex == 0) // raven
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();//raven
                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 1)
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();//owl
                    }

                    break;
                case "Fish":
                    ListBox_AnimalObj.SelectedIndex = (int)Enum.Parse(typeof(Fish_list), Animal_type);

                    TextBox_Spec1.Text = anim_info[7].Substring(anim_info[7].LastIndexOf('*') + 1).Trim();
                    TextBox_Spec2.Text = anim_info[8].Substring(anim_info[8].LastIndexOf('*') + 1).Trim();

                    if (ListBox_AnimalObj.SelectedIndex == 0) // salmon
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();
                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 1) // shark
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();
                    }

                    break;
                case "Insect":
                    ListBox_AnimalObj.SelectedIndex = (int)Enum.Parse(typeof(Insect_list), Animal_type);

                    TextBox_Spec1.Text = anim_info[7].Substring(anim_info[7].LastIndexOf('*') + 1).Trim();
                    TextBox_Spec2.Text = anim_info[8].Substring(anim_info[8].LastIndexOf('*') + 1).Trim();
                    TextBox_Spec3.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();

                    if (ListBox_AnimalObj.SelectedIndex == 0) // ant
                    {
                        TextBox_species_1.Text = anim_info[10].Substring(anim_info[10].LastIndexOf('*') + 1).Trim();
                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 1) // butterfly
                    {
                        TextBox_species_1.Text = anim_info[10].Substring(anim_info[10].LastIndexOf('*') + 1).Trim();
                    }


                    break;
                case "Mammal":
                    ListBox_AnimalObj.SelectedIndex = (int)Enum.Parse(typeof(Mammal_list), Animal_type);

                    TextBox_Spec1.Text = anim_info[7].Substring(anim_info[7].LastIndexOf('*') + 1).Trim();
                    TextBox_Spec2.Text = anim_info[8].Substring(anim_info[8].LastIndexOf('*') + 1).Trim();

                    if (ListBox_AnimalObj.SelectedIndex == 0) // cat
                    {
                        str1 = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();

                        if (str1.Equals("True"))
                        {
                            RadioBtn_Animal_spec_1.Checked = true;
                        }
                        else
                        {
                            RadioBtn_Animal_spec_1.Checked = false;
                        }

                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 1) // dog
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();
                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 2) // horse
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();
                    }

                    break;
                case "Reptile":
                    ListBox_AnimalObj.SelectedIndex = (int)Enum.Parse(typeof(Reptile_list), Animal_type);

                    TextBox_Spec1.Text = anim_info[7].Substring(anim_info[7].LastIndexOf('*') + 1).Trim();

                    str1 = anim_info[8].Substring(anim_info[8].LastIndexOf('*') + 1).Trim();

                    if (str1.Equals("True"))
                    {
                        CheckBox_Poison.Checked = true;
                    }
                    else
                    {
                        CheckBox_Poison.Checked = false;
                    }

                    if (ListBox_AnimalObj.SelectedIndex == 0) // crock
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();
                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 1) // turtle
                    {
                        str1 = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();

                        if (str1.Equals("True"))
                        {
                            RadioBtn_Animal_spec_1.Checked = true;
                        }
                        else
                        {
                            RadioBtn_Animal_spec_1.Checked = false;
                        }
                    }
                    else if (ListBox_AnimalObj.SelectedIndex == 2) // snake
                    {
                        TextBox_species_1.Text = anim_info[9].Substring(anim_info[9].LastIndexOf('*') + 1).Trim();
                    }

                    break;
            }
            Text_Box_Name_Input.Text = animal.name;
            Text_Box_Age_Input.Text = animal.age.ToString();
            Text_Box_Weight_Input.Text = animal.weight.ToString();
            Text_Box_Behaviour_Input.Text = animal.behavior.ToString();
        }

        

        /// <summary>
        /// Sortes ListView items and animals
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Animals_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //this.ListView_Animals.ListViewItemSorter = new ListViewItemComparer(e.Column);

            
            IComparer<Animal> comparer_1 = new Current_Comparer(e.Column);
            Animal_manager.Sort_any_List(comparer_1);

            ListView_Animals.Items.Clear();

            for (int i = 0; i<Animal_manager.Count; i++)
            {
                Animal new_an = Animal_manager.GetAt(i);
                string[] row1 = { new_an.name.ToString(), new_an.age.ToString(), new_an.gender.ToString(), new_an.GetExtraInfo() };

                ListView_Animals.Items.Add(new_an.id.ToString());
                ListView_Animals.Items[ListView_Animals.Items.Count - 1].SubItems.AddRange(row1);

            }

        }
        /// <summary>
        /// Adds Food Item to the Food List by clicking Add Food button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_FoodItem_Click(object sender, EventArgs e)
        {
            Form_Add_Food recipeForm = new Form_Add_Food();
            if (recipeForm.ShowDialog() == DialogResult.OK)
            {
                
                Food_Item new_food = new Food_Item();
                new_food = recipeForm.Fooditem;
                Food_manager.Add(new_food);
                ListBoxFoodItem.Items.Add(new_food.ToString());

                Food_manager_saved = false;
            }
        }

        private void Btn_Change_Click(object sender, EventArgs e)
        {
            if (ListView_Animals.FocusedItem == null)
            {
                return;
            }

            int index = ListView_Animals.FocusedItem.Index;

            if (index == -1)
            {
                return;
            }

            int selected_id =  Convert.ToInt32(ListView_Animals.SelectedItems[0].Text.Trim());

            Animal selected_animal = Animal_manager.GetAt(index);

            String sel_anim_species = selected_animal.GetType().Name;
            String current_species = ListBox_AnimalObj.SelectedItem.ToString();

            if (!sel_anim_species.Equals(current_species))
            {
                MessageBox.Show("You can only change within same species.");
                return;
            }

            bool correct_input = IsInputCorrect();
            Animal new_an = null;

            if (correct_input)
            {
                new_an = Read_input_and_create_animal();

                if (new_an != null)
                {
                    
                    new_an.name = Text_Box_Name_Input.Text.Trim();
                    UInt32 anim_age;
                    UInt32.TryParse(Text_Box_Age_Input.Text, out anim_age);
                    new_an.age = anim_age;
                    UInt32 anim_weight;
                    UInt32.TryParse(Text_Box_Weight_Input.Text, out anim_weight);
                    new_an.weight = anim_weight;
                    new_an.behavior = Text_Box_Behaviour_Input.Text.Trim();
                    new_an.gender = (GenderType)ListBox_Gender.SelectedIndex;
                    new_an.category = (CategoryType)ListBox_CategoryType.SelectedIndex;
                    new_an.id = (uint)selected_id;

                    string test = new_an.GetType().Name;

                    Animal_manager.ChangeAt(new_an, index);
                    Animal_manager_saved = false;

                    Text_Box_Name_Input.Text = "";
                    Text_Box_Age_Input.Text = "";
                    Text_Box_Weight_Input.Text = "";
                    Text_Box_Behaviour_Input.Text = "";

                    String info = new_an.ToString().Replace(";", ";\n");
                    info = info.Replace("*", " ");

                    String animal_type = new_an.GetType().Name;

                    Lbl_animal_info.Text = "Animal info: " + "\n" + " " + animal_type + "\n" + info;
                    Update_GUI_by_Category(new_an.category);
                    Update_GUI_by_Animal_Type();
                    //string[] row1 = { new_an.name.ToString(), new_an.age.ToString(), new_an.gender.ToString(), new_an.GetExtraInfo() };

                    ListView_Animals.Items[index].SubItems[1].Text = new_an.name.ToString();
                    ListView_Animals.Items[index].SubItems[2].Text = new_an.age.ToString();
                    ListView_Animals.Items[index].SubItems[3].Text = new_an.gender.ToString();
                    ListView_Animals.Items[index].SubItems[4].Text = new_an.GetExtraInfo();

                    ListView_Animals.Items[index].Focused = true;
                    ListView_Animals.Items[index].Selected = true;

                }
            }

         }
        /// <summary>
        /// Delete animal from the animal list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (ListView_Animals.FocusedItem == null)
            {
                return;
            }
            int index = ListView_Animals.FocusedItem.Index;

            if (index == -1)
            {
                return;
            }
            int selected_id = Convert.ToInt32(ListView_Animals.SelectedItems[0].Text.Trim());

            Animal_manager.DeleteAt(index);
            Ids.Remove((uint)selected_id);
            Animal_manager.Delete_animal_from_food_dictionary(selected_id);
            Animal_manager_saved = false;

            ListView_Animals.SelectedItems[0].Remove();
            if (index > 0)
            {
                ListView_Animals.Items[index - 1].Focused = true;
                ListView_Animals.Items[index - 1].Selected = true;
            }
            else 
            {
                if (ListView_Animals.Items.Count > 0)
                {
                    ListView_Animals.Items[index].Focused = true;
                    ListView_Animals.Items[index].Selected = true;
                }
            }

            if (Animal_manager.Count == 0)
            {
                Lbl_animal_info.Text = "Animal_info: ";
                ListBox_Food.Items.Clear();
                Text_Box_Name_Input.Text = "";
                Text_Box_Age_Input.Text = "";
                Text_Box_Behaviour_Input.Text = "";
                Text_Box_Weight_Input.Text = "";

                TextBox_Spec1.Text = "";
                TextBox_Spec2.Text = "";
                TextBox_Spec3.Text = "";

                TextBox_species_1.Text = "";
                RadioBtn_Animal_spec_1.Checked = false;
                CheckBox_Poison.Checked = false;
            }
        }
        /// <summary>
        /// Connect animal to a chosen food item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if (ListView_Animals.FocusedItem == null)
            {
                return;
            }
            int index = ListView_Animals.FocusedItem.Index;

            if (index == -1)
            {
                return;
            }
            int food_index = ListBoxFoodItem.SelectedIndex;
            if (food_index == -1)
            {
                return;
            }
            int selected_id = Convert.ToInt32(ListView_Animals.SelectedItems[0].Text.Trim());

            if (Animal_manager.Connect_food_animal(food_index, selected_id))
            {
                ListBox_Food.Items.Clear();
                
                string[] new_food_info = Food_manager.GetAt(food_index).ToStringArray();

                ListBox_Food.Items.AddRange(new_food_info);

                Animal_manager_saved = false;
            }

        }
        
        /// <summary>
        /// When user clicks New, re-initializes the program or if
        /// there was unsaved data asks if this data should be discarded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_New_Click(object sender, EventArgs e)
        {            

            if (!Animal_manager_saved)
            {
                if (MessageBox.Show("Animal information is changed but not saved. " +
                    "Are you sure you want to start from scratch and loose all unsaved changes?", "New", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!Food_manager_saved)
                    {
                        if (MessageBox.Show("Food information is changed but not saved. " +
                            "Are you sure you want to start from scratch and loose all unsaved changes?", "New", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;

                        }
                    }
                }
                else
                {
                    return;
                }
            }
            else if (!Food_manager_saved)
            {
                if (MessageBox.Show("Food information is changed but not saved. " +
                    "Are you sure you want to start from scratch and loose all unsaved changes?", "New", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;

                }
            }

            Animal_manager = new AnimalManager();
            Ids = new List<uint>();
            Food_manager = new FoodManager();
            
            Initialize_GUI(0);
        }
        /// <summary>
        /// Not implemented: Read Animal List from text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Open_Text_File_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles Open Binary file menu click
        /// Binary file is loaded, deserialized 
        /// and GUI updated accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Open_Bin_File_Click(object sender, EventArgs e)
        {
            if (!Animal_manager_saved)
            {
                if (MessageBox.Show("Animal information is changed but not saved. " +
                    "Are you sure you want to start from scratch and loose all unsaved changes?", "New", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
               
            }

            if (!Animal_manager_saved)
            {
                if (MessageBox.Show("Animal information is changed but not saved. " +
                    "Are you sure you want to close?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
                openFileDialog.Filter = "binary files (*.dat)|*.dat";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = string.Empty;
                    filePath = openFileDialog.FileName;

                    Animal_manager = new AnimalManager();
                    Ids = new List<uint>();

                    Initialize_GUI(1);

                    try
                    {
                        Animal_manager.BinaryDeSerialize(filePath);

                        if (Animal_manager != null)
                        {
                            if (Animal_manager.Count > 0)
                            {
                                ListView_Animals.Items.Clear();

                                for (int i = 0; i < Animal_manager.Count; i++)
                                {
                                    Animal new_an = Animal_manager.GetAt(i);
                                    Ids.Add(new_an.id);

                                    string[] row1 = { new_an.name.ToString(), new_an.age.ToString(), new_an.gender.ToString(), new_an.GetExtraInfo() };

                                    ListView_Animals.Items.Add(new_an.id.ToString());
                                    ListView_Animals.Items[ListView_Animals.Items.Count - 1].SubItems.AddRange(row1);

                                    ListView_Animals.Items[0].Selected = true;
                                    ListView_Animals.Items[0].Focused = true;

                                    ListView_Animals_SelectedIndexChanged_update_GUI();
                                }
                            }
                            Animal_manager_file_path = filePath;
                        }
                    }
                    
                    catch (FileLoadException)
                    {
                        MessageBox.Show("File cannot be loaded", "Error");
                    }
                    
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Access to file is unautorized.", "Error");
                    }
                    catch (Exception exception2)
                    {
                        MessageBox.Show(exception2.ToString(), "Error");
                    }
                    finally
                    {
                        
                    }
                }
            }
        }
        /// <summary>
        /// Handles Save menu click. If there are saved paths
        /// they will be used otherwise, Save as logic is used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Save_Click(object sender, EventArgs e)
        {
            if (Animal_manager_file_path.Equals("")) // saves as BINARY
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Text|*.txt";
                saveFileDialog1.Title = "Save a text File";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog1.FileName;
                    Save_Animal_List_as_BIN(fileName);
                }
            }
            else
            {
                string extension = System.IO.Path.GetExtension(Animal_manager_file_path);

                if (extension.Equals(".dat"))
                {
                    Save_Animal_List_as_BIN(Animal_manager_file_path);
                }
                else if (extension.Equals(".txt"))
                {
                    Save_Animal_List_as_Text(Animal_manager_file_path);
                }
                else
                {
                    MessageBox.Show("Animal list can only be saved as *.dat or *.xml file, got extension = " + extension);
                }

            }
        }
        /// <summary>
        /// Saves Animal List to text file
        /// </summary>
        /// <param name="fileName"></param>
        private void Save_Animal_List_as_Text(string fileName)
        {
            try
            {
                Animal_manager.Save_List_as_TextFile(fileName);
            }
            
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to file is unautorized.", "Error");
            }
            catch (Exception exception3)
            {
                MessageBox.Show(exception3.ToString(), "Error");
            }
        }
        /// <summary>
        ///Handles Menu Animal List to text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Save_As_Text_File_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            saveFileDialog1.Filter = "Text|*.txt";
            saveFileDialog1.Title = "Save a text File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                Save_Animal_List_as_Text(fileName);
            }
        }
        /// <summary>
        /// Calls libraries for saving Animal List to binary file
        /// </summary>
        /// <param name="fileName"></param>
        void Save_Animal_List_as_BIN(string fileName)
        {
            
            try
            {
                Animal_manager.BinarySerialize(fileName);
                Animal_manager_saved = true;
                Animal_manager_file_path = fileName;
            }
            
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Access to file is unautorized.", "Error");
            }
            catch (Exception exception4)
            {
                MessageBox.Show(exception4.ToString(), "Error");
            }
            finally
            {

            }
        }
        /// <summary>
        /// Handles Menu save Animal List to binary file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Save_As_Bin_File_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            saveFileDialog1.Filter = "Bin|*.dat";
            saveFileDialog1.Title = "Save a binary File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                Save_Animal_List_as_BIN(fileName);
            }
            
        }
        /// <summary>
        /// Handles read from XML file
        /// IF somethinf goes wrong, an Exception error message
        /// containing all information will be given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_XML_Import_Click(object sender, EventArgs e)
        {
            if (!Food_manager_saved)
            {
                if (MessageBox.Show("Food information is changed but not saved. " +
                    "Are you sure you want to read new file and discard current changes?", "Exiting", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
                openFileDialog.Filter = "XML files|*.xml"; 
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                try
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = string.Empty;
                        filePath = openFileDialog.FileName;
                        Food_manager.DeleteAll();
                        Food_manager.XMLDeSerialize(filePath);
                        ListBoxFoodItem.Items.Clear();

                        if (Food_manager != null)
                        {
                            if (Food_manager.Count > 0)
                            {
                                Food_Item new_food;

                                for (int i = 0; i < Food_manager.Count; i++)
                                {
                                    new_food = Food_manager.GetAt(i);
                                    ListBoxFoodItem.Items.Add(new_food.ToString());
                                }
                            }
                            Food_manager_file_path = filePath;
                        }

                    }
                }                
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access to file is unautorized.", "Error");
                }
                catch (Exception exception5)
                {
                    MessageBox.Show(exception5.ToString(), "Error");
                }
                finally
                {

                }
                
            }
        }
        /// <summary>
        /// Handles export of Food List to XML file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_XML_Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer.ToString();
            saveFileDialog1.Filter = "XML|*.xml";
            saveFileDialog1.Title = "Save an XML File";
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;
                try
                {
                    Food_manager.XMLSerialize(fileName);
                    Food_manager_saved = true;
                    Food_manager_file_path = fileName;
                }                
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show("Access to file is unautorized.", "Error");
                }
                catch (Exception exeption1)
                {
                     MessageBox.Show(exeption1.ToString(), "Error"); 
                }
            }
        }
        /// <summary>
        /// Handles  closing form event, if user closes by pressing X or Exit menu
        /// If unsaved changes detected, user informed they can be lost if proceed with close
        /// </summary>
        private bool Closing_Form_Check_is_Save_needed()
        {
            bool Exit_ok = false;
            if ((Animal_manager_saved) & (Food_manager_saved))
            {
                Exit_ok = true;
                return Exit_ok;
            }

            if((Animal_manager.Count == 0) & (Food_manager.Count == 0))
            {
                Exit_ok = true;
                return Exit_ok;
            }

            if (!Animal_manager_saved)
            {
                if (MessageBox.Show("Animal information is changed but not saved. " +
                    "Are you sure you want to close?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (!Food_manager_saved)
                    {
                        if (MessageBox.Show("Food information is changed bbut not saved. " +
                            "Are you sure you want to close?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Exit_ok = true;

                        }
                        else
                        {
                            return Exit_ok;
                        }
                    }
                    Exit_ok = true;

                }
                else
                {
                    return Exit_ok;
                }
            }

            if (!Food_manager_saved)
            {
                if (MessageBox.Show("Food information is changed bbut not saved. " +
                    "Are you sure you want to close?", "Exiting", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Exit_ok = true;
                }
                else
                {
                    return Exit_ok; 
                }
            }
            return Exit_ok;
        }
        /// <summary>
        /// Handles event of User Clicking Menu Exit
        /// If unsaved changes exist user will be informed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            if (Closing_Form_Check_is_Save_needed())
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// Handles event of user click on a List View row
        /// containing all created animals individuals
        /// Updates GUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_Animals_MouseClick(object sender, MouseEventArgs e)
        {

            for (int i = 0; i < ListView_Animals.Items.Count; i++)
            {
                var rectangle = ListView_Animals.GetItemRect(i);
                if (rectangle.Contains(e.Location))
                {
                    ListView_Animals_SelectedIndexChanged_update_GUI();

                }
            }

        }
        /// <summary>
        /// Handles closing form by pressing X
        /// if any unsaved changes, user will be informed that they will be lost
        /// if proceeded with closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Closing_Form_Check_is_Save_needed())
            {
                e.Cancel = true;
            }
        }

        private void GrpBox_AnimalInfo_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
