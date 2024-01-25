using System;
using System.Drawing;
using System.Windows.Forms;
namespace DefinitelyMyFault
{
    public sealed class MainForm : Form
    {
        #region Public Constants
        public const string defaultErrorCode = "0xc0000022";

        public static readonly Color formColor = Color.FromArgb(255, 225, 225, 225);
        public const double formWidth = 0.2;
        public const double formHeight = 0.25;

        public const double upperContainerWidth = 1;
        public const double upperContainerHeight = 0.5;

        public const double upperUpperContainerWidth = 1;
        public const double upperUpperContainerHeight = 0.5;

        public const double upperLowerContainerWidth = 1;
        public const double upperLowerContainerHeight = 0.5;

        public const double lowerContainerWidth = 1;
        public const double lowerContainerHeight = 0.5;

        public static readonly Color errorCodeLabelTextColor = Color.FromArgb(255, 0, 0, 0);
        public const double errorCodeLabelWidth = 1;
        public const double errorCodeLabelHeight = 0.8;

        public static readonly Color errorCodeTextBoxBackColor = Color.FromArgb(255, 175, 175, 175);
        public static readonly Color errorCodeTextBoxTextColor = Color.FromArgb(255, 0, 0, 0);
        public const double errorCodeTextBoxWidth = 1;
        public const double errorCodeTextBoxHeight = 0.8;


        public static readonly Color invokeBSODButtonDefaultBackColor = Color.FromArgb(255, 175, 175, 175);
        public static readonly Color invokeBSODButtonDefaultTextColor = Color.FromArgb(255, 0, 0, 0);
        public static readonly Color invokeBSODButtonHoverBackColor = Color.FromArgb(255, 75, 75, 75);
        public static readonly Color invokeBSODButtonHoverTextColor = Color.FromArgb(255, 0, 0, 0);
        public const double invokeBSODButtonWidth = 0.8;
        public const double invokeBSODButtonHeight = 0.8;
        #endregion
        #region Private Variables
        private Label errorCodeLabel = null;
        private TextBox errorCodeTextBox = null;
        private Button invokeBSODButton = null;
        #endregion
        #region Public Constructors
        public MainForm()
        {
            #region Renderring
            Screen screen = Screen.AllScreens[0];

            int screenPositionX = screen.Bounds.X;
            int screenPositionY = screen.Bounds.Y;
            int screenWidth = screen.Bounds.Width;
            int screenHeight = screen.Bounds.Height;

            int formScreenWidth = (int)(screenWidth * formWidth);
            int formScreenHeight = (int)(screenHeight * formHeight);
            int formScreenX = (screenWidth - formScreenWidth) >> 1;
            int formScreenY = (screenHeight - formScreenHeight) >> 1;

            int formPixelWidth = formScreenWidth;
            int formPixelHeight = formScreenHeight;
            int formPixelX = 0;
            int formPixelY = 0;

            int upperContainerPixelWidth = (int)(formPixelWidth * upperContainerWidth);
            int upperContainerPixelHeight = (int)(formPixelHeight * upperContainerHeight);
            int upperContainerPixelX = formPixelX + 0;
            int upperContainerPixelY = formPixelY + 0;

            int lowerContainerPixelWidth = (int)(formPixelWidth * lowerContainerWidth);
            int lowerContainerPixelHeight = (int)(formPixelHeight * lowerContainerHeight);
            int lowerContainerPixelX = formPixelX + 0;
            int lowerContainerPixelY = upperContainerPixelY + upperContainerPixelHeight;

            int upperUpperContainerPixelWidth = (int)(upperContainerPixelWidth * upperUpperContainerWidth);
            int upperUpperContainerPixelHeight = (int)(upperContainerPixelHeight * upperUpperContainerHeight);
            int upperUpperContainerPixelX = upperContainerPixelX;
            int upperUpperContainerPixelY = upperContainerPixelY;

            int upperLowerContainerPixelWidth = (int)(upperContainerPixelWidth * upperLowerContainerWidth);
            int upperLowerContainerPixelHeight = (int)(upperContainerPixelHeight * upperLowerContainerHeight);
            int upperLowerContainerPixelX = upperUpperContainerPixelX;
            int upperLowerContainerPixelY = upperUpperContainerPixelY + upperUpperContainerPixelHeight;

            int errorCodeLabelPixelWidth = (int)(upperUpperContainerPixelWidth * errorCodeLabelWidth);
            int errorCodeLabelPixelHeight = (int)(upperUpperContainerPixelHeight * errorCodeLabelHeight);
            int errorCodeLabelPixelX = upperUpperContainerPixelX + ((upperUpperContainerPixelWidth - errorCodeLabelPixelWidth) >> 1);
            int errorCodeLabelPixelY = upperUpperContainerPixelY + ((upperUpperContainerPixelHeight - errorCodeLabelPixelHeight) >> 1);

            int errorCodeTextBoxPixelWidth = (int)(upperLowerContainerPixelWidth * errorCodeTextBoxWidth);
            int errorCodeTextBoxPixelHeight = (int)(upperLowerContainerPixelHeight * errorCodeTextBoxHeight);
            int errorCodeTextBoxPixelX = upperLowerContainerPixelX + ((upperLowerContainerPixelWidth - errorCodeTextBoxPixelWidth) >> 1);
            int errorCodeTextBoxPixelY = upperLowerContainerPixelY + ((upperLowerContainerPixelHeight - errorCodeTextBoxPixelHeight) >> 1);

            int invokeBSODButtonPixelWidth = (int)(lowerContainerPixelWidth * invokeBSODButtonWidth);
            int invokeBSODButtonPixelHeight = (int)(lowerContainerPixelHeight * invokeBSODButtonHeight);
            int invokeBSODButtonPixelX = lowerContainerPixelX + ((lowerContainerPixelWidth- invokeBSODButtonPixelWidth) >> 1);
            int invokeBSODButtonPixelY = lowerContainerPixelY + ((lowerContainerPixelHeight - invokeBSODButtonPixelHeight) >> 1);
            #endregion
            #region Controls
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Definitely My Fault";
            this.Location = new Point(formScreenX, formScreenY);
            this.ClientSize = new Size(formScreenWidth, formScreenHeight);
            this.BackColor = formColor;

            errorCodeLabel = new Label();
            errorCodeLabel.Text = "Hard Error Code:";
            errorCodeLabel.Font = new Font("Microsoft Sans Serif", 8.25f * 1.5f, FontStyle.Regular); ;
            errorCodeLabel.TextAlign = ContentAlignment.MiddleLeft;
            errorCodeLabel.ForeColor = errorCodeLabelTextColor;
            errorCodeLabel.Width = errorCodeLabelPixelWidth;
            errorCodeLabel.Height = errorCodeLabelPixelHeight;
            errorCodeLabel.Location = new Point(errorCodeLabelPixelX, errorCodeLabelPixelY);
            this.Controls.Add(errorCodeLabel);

            errorCodeTextBox = new TextBox();
            errorCodeTextBox.Width = errorCodeTextBoxPixelWidth;
            errorCodeTextBox.Height = errorCodeTextBoxPixelHeight;
            errorCodeTextBox.Location = new Point(errorCodeTextBoxPixelX, errorCodeTextBoxPixelY);
            errorCodeTextBox.Text = defaultErrorCode;
            errorCodeTextBox.TextAlign = HorizontalAlignment.Center;
            errorCodeTextBox.ForeColor = errorCodeLabelTextColor;
            errorCodeTextBox.BackColor = errorCodeTextBoxBackColor;
            this.Controls.Add(errorCodeTextBox);

            invokeBSODButton = new Button();
            invokeBSODButton.Width = invokeBSODButtonPixelWidth;
            invokeBSODButton.Height = invokeBSODButtonPixelHeight;
            invokeBSODButton.Location = new Point(invokeBSODButtonPixelX, invokeBSODButtonPixelY);
            invokeBSODButton.Text = "Invoke BSOD!";
            invokeBSODButton.TextAlign = ContentAlignment.MiddleCenter;
            invokeBSODButton.MouseEnter += OnInvokeBSODButtonHoverEnter;
            invokeBSODButton.MouseLeave += OnInvokeBSODButtonHoverExit;
            invokeBSODButton.Click += OnInvokeBSODButtonClicked;
            invokeBSODButton.ForeColor = invokeBSODButtonDefaultTextColor;
            invokeBSODButton.BackColor = invokeBSODButtonDefaultBackColor;
            invokeBSODButton.Font = new Font("Microsoft Sans Serif", 16.5f, FontStyle.Regular);
            this.AcceptButton = invokeBSODButton;
            this.Controls.Add(invokeBSODButton);

            Button virtualCancelButton = new Button();
            virtualCancelButton.Click += OnVirtualCancelButtonClicked;
            this.CancelButton = virtualCancelButton;
            #endregion
        }
        #endregion
        #region Private Events
        private void OnInvokeBSODButtonHoverEnter(object sender, EventArgs e)
        {
            invokeBSODButton.ForeColor = invokeBSODButtonHoverTextColor;
            invokeBSODButton.BackColor = invokeBSODButtonHoverBackColor;
        }
        private void OnInvokeBSODButtonHoverExit(object sender, EventArgs e)
        {
            invokeBSODButton.ForeColor = invokeBSODButtonDefaultTextColor;
            invokeBSODButton.BackColor = invokeBSODButtonDefaultBackColor;
        }
        private void OnInvokeBSODButtonClicked(object sender, EventArgs e)
        {
            InvokeBSOD();
        }
        private void OnVirtualCancelButtonClicked(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        #endregion
        #region Private Methods
        private bool ErrorCodeIsValid()
        {
            try
            {
                IntParsingHelper.ParseUint(errorCodeTextBox.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void InvokeBSOD()
        {
            if (ErrorCodeIsValid())
            {
                try
                {
                    BSODHelper.RaiseHardException(IntParsingHelper.ParseUint(errorCodeTextBox.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: Could not invoke BSOD due to exception: {ex.Message}", "Error!", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error code is invalid. Please supply a valid 32 bit unsigned integer in either decimal or hex format.", "Invalid Input", MessageBoxButtons.OK);
            }
        }
        #endregion
    }
}
