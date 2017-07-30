namespace jiudiandashaojilv.cms_yrz
{
    partial class Form_xf
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_xf));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jiudiandashaojiluDataSet = new jiudiandashaojilv.jiudiandashaojiluDataSet();
            this.housingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.housingTableAdapter = new jiudiandashaojilv.jiudiandashaojiluDataSetTableAdapters.housingTableAdapter();
            this.roomnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruzujiageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jiaokuanshuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruzutianshuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yajinshuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruzushijianDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yulishijianDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yizhutianshuDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yingfanjineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.koufeijineDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiudiandashaojiluDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.housingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 35;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roomnoDataGridViewTextBoxColumn,
            this.ruzujiageDataGridViewTextBoxColumn,
            this.jiaokuanshuDataGridViewTextBoxColumn,
            this.ruzutianshuDataGridViewTextBoxColumn,
            this.yajinshuDataGridViewTextBoxColumn,
            this.ruzushijianDataGridViewTextBoxColumn,
            this.yulishijianDataGridViewTextBoxColumn,
            this.yizhutianshuDataGridViewTextBoxColumn,
            this.yingfanjineDataGridViewTextBoxColumn,
            this.koufeijineDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.housingBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1030, 72);
            this.dataGridView1.TabIndex = 3;
            // 
            // jiudiandashaojiluDataSet
            // 
            this.jiudiandashaojiluDataSet.DataSetName = "jiudiandashaojiluDataSet";
            this.jiudiandashaojiluDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // housingBindingSource
            // 
            this.housingBindingSource.DataMember = "housing";
            this.housingBindingSource.DataSource = this.jiudiandashaojiluDataSet;
            // 
            // housingTableAdapter
            // 
            this.housingTableAdapter.ClearBeforeFill = true;
            // 
            // roomnoDataGridViewTextBoxColumn
            // 
            this.roomnoDataGridViewTextBoxColumn.DataPropertyName = "roomno";
            this.roomnoDataGridViewTextBoxColumn.HeaderText = "房间号";
            this.roomnoDataGridViewTextBoxColumn.Name = "roomnoDataGridViewTextBoxColumn";
            this.roomnoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ruzujiageDataGridViewTextBoxColumn
            // 
            this.ruzujiageDataGridViewTextBoxColumn.DataPropertyName = "ruzujiage";
            this.ruzujiageDataGridViewTextBoxColumn.HeaderText = "房价";
            this.ruzujiageDataGridViewTextBoxColumn.Name = "ruzujiageDataGridViewTextBoxColumn";
            this.ruzujiageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // jiaokuanshuDataGridViewTextBoxColumn
            // 
            this.jiaokuanshuDataGridViewTextBoxColumn.DataPropertyName = "jiaokuanshu";
            this.jiaokuanshuDataGridViewTextBoxColumn.HeaderText = "交款金额";
            this.jiaokuanshuDataGridViewTextBoxColumn.Name = "jiaokuanshuDataGridViewTextBoxColumn";
            this.jiaokuanshuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ruzutianshuDataGridViewTextBoxColumn
            // 
            this.ruzutianshuDataGridViewTextBoxColumn.DataPropertyName = "ruzutianshu";
            this.ruzutianshuDataGridViewTextBoxColumn.HeaderText = "入住天数";
            this.ruzutianshuDataGridViewTextBoxColumn.Name = "ruzutianshuDataGridViewTextBoxColumn";
            this.ruzutianshuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yajinshuDataGridViewTextBoxColumn
            // 
            this.yajinshuDataGridViewTextBoxColumn.DataPropertyName = "yajinshu";
            this.yajinshuDataGridViewTextBoxColumn.HeaderText = "押金数";
            this.yajinshuDataGridViewTextBoxColumn.Name = "yajinshuDataGridViewTextBoxColumn";
            this.yajinshuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ruzushijianDataGridViewTextBoxColumn
            // 
            this.ruzushijianDataGridViewTextBoxColumn.DataPropertyName = "ruzushijian";
            this.ruzushijianDataGridViewTextBoxColumn.HeaderText = "入住时间";
            this.ruzushijianDataGridViewTextBoxColumn.Name = "ruzushijianDataGridViewTextBoxColumn";
            this.ruzushijianDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yulishijianDataGridViewTextBoxColumn
            // 
            this.yulishijianDataGridViewTextBoxColumn.DataPropertyName = "yulishijian";
            this.yulishijianDataGridViewTextBoxColumn.HeaderText = "预离时间";
            this.yulishijianDataGridViewTextBoxColumn.Name = "yulishijianDataGridViewTextBoxColumn";
            this.yulishijianDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yizhutianshuDataGridViewTextBoxColumn
            // 
            this.yizhutianshuDataGridViewTextBoxColumn.DataPropertyName = "yizhutianshu";
            this.yizhutianshuDataGridViewTextBoxColumn.HeaderText = "已住天数";
            this.yizhutianshuDataGridViewTextBoxColumn.Name = "yizhutianshuDataGridViewTextBoxColumn";
            this.yizhutianshuDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // yingfanjineDataGridViewTextBoxColumn
            // 
            this.yingfanjineDataGridViewTextBoxColumn.DataPropertyName = "yingfanjine";
            this.yingfanjineDataGridViewTextBoxColumn.HeaderText = "应返金额";
            this.yingfanjineDataGridViewTextBoxColumn.Name = "yingfanjineDataGridViewTextBoxColumn";
            this.yingfanjineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // koufeijineDataGridViewTextBoxColumn
            // 
            this.koufeijineDataGridViewTextBoxColumn.DataPropertyName = "koufeijine";
            this.koufeijineDataGridViewTextBoxColumn.HeaderText = "扣费金额";
            this.koufeijineDataGridViewTextBoxColumn.Name = "koufeijineDataGridViewTextBoxColumn";
            this.koufeijineDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form_xf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1030, 392);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_xf";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "续费";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jiudiandashaojiluDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.housingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource housingBindingSource;
        private jiudiandashaojiluDataSet jiudiandashaojiluDataSet;
        private jiudiandashaojiluDataSetTableAdapters.housingTableAdapter housingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruzujiageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jiaokuanshuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruzutianshuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yajinshuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruzushijianDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yulishijianDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yizhutianshuDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yingfanjineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn koufeijineDataGridViewTextBoxColumn;
    }
}