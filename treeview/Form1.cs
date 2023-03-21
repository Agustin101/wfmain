namespace treeview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Text = "Rayo";
            treeNode.Name = "Rayo";
            var subNode1 = new TreeNode("Pikachu", 0, 0);
            subNode1.Name = "Pikachu";
            subNode1.Tag = "name=pikachu kms=15 img=0";
            treeView1.ImageList = imageList1;
            treeNode.Nodes.Add(subNode1);
            treeView1.Nodes.Add(treeNode);
            treeView1.AllowDrop = true;

            TreeNode treeNode2 = new TreeNode();
            treeNode2.Text = "Fuego";
            treeNode2.Name = "Fuego";
            var subNode11 = new TreeNode("Charmander");
            subNode11.Name = "Charmander";
            treeNode2.Nodes.Add(subNode11);
            treeView1.Nodes.Add(treeNode2);

            treeNode.Nodes[0].Expand();
            treeNode2.Nodes[0].Expand();

        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode selectedNode = treeView1.GetNodeAt(e.X, e.Y);
                if (selectedNode != null && selectedNode.Level != 0)
                {
                    treeView1.SelectedNode = selectedNode;
                    treeView1.DoDragDrop(selectedNode.Tag, DragDropEffects.Copy);
                }
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string draggedText = (string)e.Data.GetData(DataFormats.Text);
                Panel p = new Panel();
                Label l = new Label();
                p.Dock = DockStyle.Fill;
                l.Text = draggedText.Substring(draggedText.IndexOf('=') + 1, 7);
                l.Visible = true;
                l.MouseDown += L_MouseDown;
                p.BackColor = Color.RebeccaPurple;

                p.Controls.Add(l);
                // Use the draggedText to populate the panel
                panel1.Controls.Add(p);
                treeView1.SelectedNode.Remove();// .RemoveByKey(draggedText.Substring(draggedText.IndexOf('=') + 1, 7));
            }
        }

        private void L_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label l = (Label)sender;
                if (l is not null)
                {
                    l.DoDragDrop(l.Text, DragDropEffects.Copy);
                }
            }
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string draggedText = (string)e.Data.GetData(DataFormats.Text);
                TreeNode node = new TreeNode();
                node.Text = draggedText;
                treeView1.Nodes[0].Nodes.Add(draggedText);
                
            }
        }
    }
}