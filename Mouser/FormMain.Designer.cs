namespace Mouser
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing) components?.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblMouseWrapper = new System.Windows.Forms.Label();
            this.cbMouseWrapper = new System.Windows.Forms.ComboBox();
            this.lblMoveMode = new System.Windows.Forms.Label();
            this.pnlMoveModes = new System.Windows.Forms.Panel();
            this.rbMoveModeAccelerating = new System.Windows.Forms.RadioButton();
            this.rbMoveModeFixed = new System.Windows.Forms.RadioButton();
            this.lblBaseSpeed = new System.Windows.Forms.Label();
            this.tbFixedSpeed = new System.Windows.Forms.TextBox();
            this.lblAccelerationMilliseconds = new System.Windows.Forms.Label();
            this.tbAccelerationMilliseconds = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel.SuspendLayout();
            this.pnlMoveModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.SetColumnSpan(this.btnStartStop, 2);
            this.btnStartStop.Location = new System.Drawing.Point(4, 4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(445, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(
                new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.btnStartStop, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblMouseWrapper, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.cbMouseWrapper, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.lblMoveMode, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.pnlMoveModes, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.lblBaseSpeed, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.tbFixedSpeed, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.lblAccelerationMilliseconds, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.tbAccelerationMilliseconds, 1, 4);
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(
                new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(453, 291);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // lblMouseWrapper
            // 
            this.lblMouseWrapper.AutoSize = true;
            this.lblMouseWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMouseWrapper.Location = new System.Drawing.Point(4, 31);
            this.lblMouseWrapper.Name = "lblMouseWrapper";
            this.lblMouseWrapper.Size = new System.Drawing.Size(219, 29);
            this.lblMouseWrapper.TabIndex = 1;
            this.lblMouseWrapper.Text = "MouseWrapper";
            this.lblMouseWrapper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMouseWrapper
            // 
            this.cbMouseWrapper.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.cbMouseWrapper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMouseWrapper.FormattingEnabled = true;
            this.cbMouseWrapper.Location = new System.Drawing.Point(230, 34);
            this.cbMouseWrapper.Name = "cbMouseWrapper";
            this.cbMouseWrapper.Size = new System.Drawing.Size(219, 23);
            this.cbMouseWrapper.TabIndex = 2;
            // 
            // lblMoveMode
            // 
            this.lblMoveMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveMode.Location = new System.Drawing.Point(4, 61);
            this.lblMoveMode.Name = "lblMoveMode";
            this.lblMoveMode.Size = new System.Drawing.Size(219, 68);
            this.lblMoveMode.TabIndex = 3;
            this.lblMoveMode.Text = "Art der Bewegung";
            this.lblMoveMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlMoveModes
            // 
            this.pnlMoveModes.AutoSize = true;
            this.pnlMoveModes.Controls.Add(this.rbMoveModeAccelerating);
            this.pnlMoveModes.Controls.Add(this.rbMoveModeFixed);
            this.pnlMoveModes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMoveModes.Location = new System.Drawing.Point(230, 64);
            this.pnlMoveModes.Name = "pnlMoveModes";
            this.pnlMoveModes.Size = new System.Drawing.Size(219, 60);
            this.pnlMoveModes.TabIndex = 4;
            // 
            // rbMoveModeAccelerating
            // 
            this.rbMoveModeAccelerating.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.rbMoveModeAccelerating.Location = new System.Drawing.Point(3, 33);
            this.rbMoveModeAccelerating.Name = "rbMoveModeAccelerating";
            this.rbMoveModeAccelerating.Size = new System.Drawing.Size(213, 24);
            this.rbMoveModeAccelerating.TabIndex = 5;
            this.rbMoveModeAccelerating.TabStop = true;
            this.rbMoveModeAccelerating.Text = "Beschleunigend";
            this.rbMoveModeAccelerating.UseVisualStyleBackColor = true;
            // 
            // rbMoveModeFixed
            // 
            this.rbMoveModeFixed.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top |
                                                        System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.rbMoveModeFixed.Location = new System.Drawing.Point(3, 3);
            this.rbMoveModeFixed.Name = "rbMoveModeFixed";
            this.rbMoveModeFixed.Size = new System.Drawing.Size(213, 24);
            this.rbMoveModeFixed.TabIndex = 4;
            this.rbMoveModeFixed.TabStop = true;
            this.rbMoveModeFixed.Text = "Konstant";
            this.rbMoveModeFixed.UseVisualStyleBackColor = true;
            // 
            // lblBaseSpeed
            // 
            this.lblBaseSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaseSpeed.Location = new System.Drawing.Point(4, 130);
            this.lblBaseSpeed.Name = "lblBaseSpeed";
            this.lblBaseSpeed.Size = new System.Drawing.Size(219, 29);
            this.lblBaseSpeed.TabIndex = 5;
            this.lblBaseSpeed.Text = "Geschwindigkeit";
            this.lblBaseSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFixedSpeed
            // 
            this.tbFixedSpeed.Location = new System.Drawing.Point(230, 133);
            this.tbFixedSpeed.Name = "tbFixedSpeed";
            this.tbFixedSpeed.Size = new System.Drawing.Size(219, 23);
            this.tbFixedSpeed.TabIndex = 6;
            // 
            // lblAccelerationMilliseconds
            // 
            this.lblAccelerationMilliseconds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccelerationMilliseconds.Location = new System.Drawing.Point(4, 160);
            this.lblAccelerationMilliseconds.Name = "lblAccelerationMilliseconds";
            this.lblAccelerationMilliseconds.Size = new System.Drawing.Size(219, 29);
            this.lblAccelerationMilliseconds.TabIndex = 7;
            this.lblAccelerationMilliseconds.Text = "Beschleunigung Millisekunden";
            this.lblAccelerationMilliseconds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbAccelerationMilliseconds
            // 
            this.tbAccelerationMilliseconds.Location = new System.Drawing.Point(230, 163);
            this.tbAccelerationMilliseconds.Name = "tbAccelerationMilliseconds";
            this.tbAccelerationMilliseconds.Size = new System.Drawing.Size(219, 23);
            this.tbAccelerationMilliseconds.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(477, 417);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FormMain";
            this.Text = "mouser";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.pnlMoveModes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblMouseWrapper;
        private System.Windows.Forms.ComboBox cbMouseWrapper;
        private System.Windows.Forms.Label lblMoveMode;
        private System.Windows.Forms.RadioButton rbMoveModeFixed;
        private System.Windows.Forms.RadioButton rbMoveModeAccelerating;
        private System.Windows.Forms.Panel pnlMoveModes;
        private System.Windows.Forms.Label lblBaseSpeed;
        private System.Windows.Forms.TextBox tbFixedSpeed;
        private System.Windows.Forms.Label lblAccelerationMilliseconds;
        private System.Windows.Forms.TextBox tbAccelerationMilliseconds;
    }
}