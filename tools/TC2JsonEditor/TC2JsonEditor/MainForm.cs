using Newtonsoft.Json;

namespace TC2JsonEditor {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            // Load JSON
            VehicleRepository.Load();
            // Init Inputs
            vehicleClassCombobox.Items.AddRange(Vehicles.ValidClasses);
            ResetInputs();
            RefreshListBox();
        }

        // Input methods
        public void ResetInputs() {
            vehicleClassCombobox.SelectedIndex = 0;
            brandTextbox.Text = string.Empty;
            modelTextbox.Text = string.Empty;
            yearNumeric.Value = 0;
            tuneAeroTrackbar.Value = 5;
            tuneGearTrackbar.Value = 5;
            tuneGripFrontTrackbar.Value = 5;
            tuneGripRearTrackbar.Value = 5;
            tuneBrakePowerTrackbar.Value = 5;
            tuneBrakeBalanceTrackbar.Value = 5;
            tuneSuspCompFTrackbar.Value = 5;
            tuneSuspRebFTrackbar.Value = 5;
            tuneSuspCompRTrackbar.Value = 5;
            tuneSuspRebRTrackbar.Value = 5;
            tuneCamberFTrackbar.Value = 5;
            tuneCamberRTrackbar.Value = 5;
            tuneArbFTrackbar.Value = 5;
            tuneArbRTrackbar.Value = 5;
            SetValueLabels();
        }

        public void SetValueLabels() {
            tuneAeroValueLabel.Text = tuneAeroTrackbar.Value.ToString();
            tuneGearValueLabel.Text = tuneGearTrackbar.Value.ToString();
            tuneGripFrontValueLabel.Text = tuneGripFrontTrackbar.Value.ToString();
            tuneGripRearValueLabel.Text = tuneGripRearTrackbar.Value.ToString();
            tuneBrakePowerValueLabel.Text = tuneBrakePowerTrackbar.Value.ToString();
            tuneBrakeBalanceValueLabel.Text = tuneBrakeBalanceTrackbar.Value.ToString();
            tuneSuspCompFValueLabel.Text = tuneSuspCompFTrackbar.Value.ToString();
            tuneSuspRebFValueLabel.Text = tuneSuspRebFTrackbar.Value.ToString();
            tuneSuspCompRValueLabel.Text = tuneSuspCompRTrackbar.Value.ToString();
            tuneSuspRebRValueLabel.Text = tuneSuspRebRTrackbar.Value.ToString();
            tuneCamberFValueLabel.Text = tuneCamberFTrackbar.Value.ToString();
            tuneCamberRValueLabel.Text = tuneCamberRTrackbar.Value.ToString();
            tuneArbFValueLabel.Text = tuneArbFTrackbar.Value.ToString();
            tuneArbRValueLabel.Text = tuneArbRTrackbar.Value.ToString();
        }

        public void RefreshListBox() {
            vehicleListBox.Items.Clear();
            foreach(VehicleItem item in VehicleRepository.Vehicles) vehicleListBox.Items.Add(item);
        }

        public int[] TrackbarsToArray() => new int[] {
            tuneAeroTrackbar.Value,
            tuneGearTrackbar.Value,
            tuneGripFrontTrackbar.Value,
            tuneGripRearTrackbar.Value,
            tuneBrakePowerTrackbar.Value,
            tuneBrakeBalanceTrackbar.Value,
            tuneSuspCompFTrackbar.Value,
            tuneSuspRebFTrackbar.Value,
            tuneSuspCompRTrackbar.Value,
            tuneSuspRebRTrackbar.Value,
            tuneCamberFTrackbar.Value,
            tuneCamberRTrackbar.Value,
            tuneArbFTrackbar.Value,
            tuneArbRTrackbar.Value
        };

        public VehicleItem InputsToVehicleItem() => new(brandTextbox.Text, modelTextbox.Text, ((int)yearNumeric.Value), vehicleClassCombobox.Text, TrackbarsToArray());
        

        // Dynamically change ValueLabels
        private void tuneAeroTrackbar_Scroll(object sender, EventArgs e) => tuneAeroValueLabel.Text = tuneAeroTrackbar.Value.ToString();
        private void tuneGearTrackbar_Scroll(object sender, EventArgs e) => tuneGearValueLabel.Text = tuneGearTrackbar.Value.ToString();
        private void tuneGripFrontTrackbar_Scroll(object sender, EventArgs e) => tuneGripFrontValueLabel.Text = tuneGripFrontTrackbar.Value.ToString();
        private void tuneGripRearTrackbar_Scroll(object sender, EventArgs e) => tuneGripRearValueLabel.Text = tuneGripRearTrackbar.Value.ToString();
        private void tuneBrakePowerTrackbar_Scroll(object sender, EventArgs e) => tuneBrakePowerValueLabel.Text = tuneBrakePowerTrackbar.Value.ToString();
        private void tuneBrakeBalanceTrackbar_Scroll(object sender, EventArgs e) => tuneBrakeBalanceValueLabel.Text = tuneBrakeBalanceTrackbar.Value.ToString();
        private void tuneSuspCompFTrackbar_Scroll(object sender, EventArgs e) => tuneSuspCompFValueLabel.Text = tuneSuspCompFTrackbar.Value.ToString();
        private void tuneSuspRebFTrackbar_Scroll(object sender, EventArgs e) => tuneSuspRebFValueLabel.Text = tuneSuspRebFTrackbar.Value.ToString();
        private void tuneSuspCompRTrackbar_Scroll(object sender, EventArgs e) => tuneSuspCompRValueLabel.Text = tuneSuspCompRTrackbar.Value.ToString();
        private void tuneSuspRebRTrackbar_Scroll(object sender, EventArgs e) => tuneSuspRebRValueLabel.Text = tuneSuspRebRTrackbar.Value.ToString();
        private void tuneCamberFTrackbar_Scroll(object sender, EventArgs e) => tuneCamberFValueLabel.Text = tuneCamberFTrackbar.Value.ToString();
        private void tuneCamberRTrackbar_Scroll(object sender, EventArgs e) => tuneCamberRValueLabel.Text = tuneCamberRTrackbar.Value.ToString();
        private void tuneArbFTrackbar_Scroll(object sender, EventArgs e) => tuneArbFValueLabel.Text = tuneArbFTrackbar.Value.ToString();
        private void tuneArbRTrackbar_Scroll(object sender, EventArgs e) => tuneArbRValueLabel.Text = tuneArbRTrackbar.Value.ToString();

        // Button actions
        private void AddVehicleButton_Click(object sender, EventArgs e) {
            VehicleRepository.Add(InputsToVehicleItem());
            ResetInputs();
            RefreshListBox();
        }

        private void RemoveVehicleButton_Click(object sender, EventArgs e) {
            if(vehicleListBox.SelectedItems.Count > 0 && vehicleListBox.SelectedItem.ToString() != null) {
                VehicleRepository.Remove(vehicleListBox.SelectedItem.ToString());
            }
            RefreshListBox();
        }

        private void SaveVehiclesButton_Click(object sender, EventArgs e) => VehicleRepository.Save();
    }
}