namespace WinFormsApp1
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
            btnLoad = new Button();
            dataGridView1 = new DataGridView();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnInsertDisconnected = new Button();
            insert = new Button();
            update = new Button();
            delete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(47, 364);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(111, 33);
            btnLoad.TabIndex = 1;
            btnLoad.Text = "btnLoad";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(180, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(330, 200);
            dataGridView1.TabIndex = 2;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(367, 364);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(111, 33);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "btnUpdate";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(527, 364);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(111, 33);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnInsertDisconnected
            // 
            btnInsertDisconnected.Location = new Point(193, 364);
            btnInsertDisconnected.Name = "btnInsertDisconnected";
            btnInsertDisconnected.Size = new Size(144, 33);
            btnInsertDisconnected.TabIndex = 6;
            btnInsertDisconnected.Text = "btnInsertDisconnected";
            btnInsertDisconnected.UseVisualStyleBackColor = true;
            btnInsertDisconnected.Click += btnInsertDisconnected_Click;
            // 
            // insert
            // 
            insert.Location = new Point(131, 281);
            insert.Name = "insert";
            insert.Size = new Size(111, 33);
            insert.TabIndex = 7;
            insert.Text = "insert";
            insert.UseVisualStyleBackColor = true;
            insert.Click += insert_Click;
            // 
            // update
            // 
            update.Location = new Point(290, 281);
            update.Name = "update";
            update.Size = new Size(111, 33);
            update.TabIndex = 8;
            update.Text = "update";
            update.UseVisualStyleBackColor = true;
            update.Click += update_Click;
            // 
            // delete
            // 
            delete.Location = new Point(446, 281);
            delete.Name = "delete";
            delete.Size = new Size(111, 33);
            delete.TabIndex = 9;
            delete.Text = "delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 420);
            Controls.Add(delete);
            Controls.Add(update);
            Controls.Add(insert);
            Controls.Add(btnInsertDisconnected);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnLoad;
        private DataGridView dataGridView1;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnInsertDisconnected;
        private Button insert;
        private Button update;
        private Button delete;
    }
}
