using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQLeditor
{
    public static class Prompt
    {
        /// <summary>
        /// Propet used mainly for the events add edit delete and export
        /// </summary>
        public static Dictionary<string, string> ShowDialog(string caption, List<string> fieldNames, Dictionary<string, string> defaultValues = null)
        {
            Form prompt = new Form
            {
                Width = 400,
                Height = 200 + (fieldNames.Count * 60), // Adjust height based on the number of fields
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog, // Make the form unresizable
                MaximizeBox = false, // Disable the maximize box
                BackColor = System.Drawing.Color.White, // Set background color
                Font = new System.Drawing.Font("Segoe UI", 10) // Set a modern font
            };

            Dictionary<string, TextBox> inputBoxes = new Dictionary<string, TextBox>();
            int topOffset = 20;

            // Add labels and text boxes for each field
            foreach (var fieldName in fieldNames)
            {
                Label textLabel = new Label()
                {
                    Left = 20,
                    Top = topOffset,
                    Text = fieldName,
                    Width = 350,
                    ForeColor = System.Drawing.Color.DarkSlateGray // Set label text color
                };

                TextBox inputBox = new TextBox()
                {
                    Left = 20,
                    Top = topOffset + 30,
                    Width = 350,
                    BorderStyle = BorderStyle.FixedSingle, // Add a border to the text box
                    BackColor = System.Drawing.Color.WhiteSmoke // Set text box background color
                };

                // Set default value if provided
                if (defaultValues != null && defaultValues.ContainsKey(fieldName))
                {
                    inputBox.Text = defaultValues[fieldName];
                }

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                inputBoxes[fieldName] = inputBox;

                topOffset += 60; // Move down for the next field
            }

            // Add the "OK" button with some spacing
            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 150,
                Width = 100,
                Top = topOffset + 20, // Add extra space above the button
                Height = 30, // Set button height
                DialogResult = DialogResult.OK,
                BackColor = System.Drawing.Color.SteelBlue, // Set button background color
                ForeColor = System.Drawing.Color.White, // Set button text color
                FlatStyle = FlatStyle.Flat // Use flat style for a modern look
            };

            confirmation.FlatAppearance.BorderSize = 0; // Remove button border
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            // Show the dialog and return the results
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, string> results = new Dictionary<string, string>();
                foreach (var fieldName in fieldNames)
                {
                    results[fieldName] = inputBoxes[fieldName].Text;
                }
                return results;
            }

            return null; // Return null if the user cancels the dialog
        }
    }
}