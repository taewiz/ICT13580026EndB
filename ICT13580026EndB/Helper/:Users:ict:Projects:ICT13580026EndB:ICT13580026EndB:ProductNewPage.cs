using System;
using System.Collections.Generic;
using ICT13580068FinalA.Models;
using Xamarin.Forms;

namespace ICT13580068FinalA
{
	public partial class ProductNewPage : ContentPage
	{
		Product product;

		public ProductNewPage(Product product = null)
		{
			InitializeComponent();

			this.product = product;

			titleLabel.Text = product == null ? "เพิ่มข้อมูล" : "แก้ไขข้อ";
			saveButton.Clicked += SaveButton_Clicked;
			cancelButton.Clicked += CancelButton_Clicked;

			DepartmentPicker.Items.Add("การเงิน");
			DepartmentPicker.Items.Add("บัญชี");

			if (product != null)
			{
				nameEntry.Text = product.Name;
				LastnameEntry.Text = product.Lastname;
				AgeEntry.Text = product.Age.ToString();
				SexEntry.Text = product.Sex;
				DepartmentPicker.SelectedItem = product.Department;
				PhoneEntry.Text = product.Phone.ToString();
				AddressEditor.Text = product.Address;
				StatusEntry.Text = product.Status;
				NumEntry.Text = product.Number.ToString();
				SaralyEntry.Text = product.Saraly.ToString();


			}



		}

		async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่ใช่");

			if (isOk)
			{
				if (product == null)
				{
					product = new Product();
					product.Name = nameEntry.Text;
					product.Lastname = LastnameEntry.Text;
					product.Age = int.Parse(AgeEntry.Text);
					product.Sex = SexEntry.Text;
					product.Department = DepartmentPicker.SelectedItem.ToString();
					product.Phone = int.Parse(PhoneEntry.Text);
					product.Address = AddressEditor.Text;
					product.Status = StatusEntry.Text;
					product.Number = int.Parse(NumEntry.Text);
					product.Saraly = decimal.Parse(SaralyEntry.Text);
					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
				}
				else
				{

					product.Name = nameEntry.Text;
					product.Lastname = LastnameEntry.Text;
					product.Age = int.Parse(AgeEntry.Text);
					product.Sex = SexEntry.Text;
					product.Department = DepartmentPicker.SelectedItem.ToString();
					product.Phone = int.Parse(PhoneEntry.Text);
					product.Address = AddressEditor.Text;
					product.Status = StatusEntry.Text;
					product.Number = int.Parse(NumEntry.Text);
					product.Saraly = decimal.Parse(SaralyEntry.Text);
					var id = App.DbHelper.UpdateProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลเรียบร้อย" + id, "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}

		void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}

	}
}
