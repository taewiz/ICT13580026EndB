using System;
using System.Collections.Generic;
using ICT13580026EndB.Models;
using Xamarin.Forms;

namespace ICT13580026EndB
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


            kindPicker.Items.Add("Eco Car");
            kindPicker.Items.Add("Sedan");
            kindPicker.Items.Add("Coupe");
            kindPicker.Items.Add("Lift Back, Hatch Back");
			kindPicker.Items.Add("Sport Car");
            kindPicker.Items.Add("Muscle Car");
            kindPicker.Items.Add("Supercar");

            brandPicker.Items.Add("Porsche");
            brandPicker.Items.Add("Toyota ");
            brandPicker.Items.Add("Honda");
            brandPicker.Items.Add("Chevrolet");
            brandPicker.Items.Add("Lamborghini");
                    


            ColorPicker.Items.Add("ดำ");
			ColorPicker.Items.Add("ขาว");
            ColorPicker.Items.Add("เงิน");
            ColorPicker.Items.Add("ฟ้า");
            ColorPicker.Items.Add("เทา");

            ProvincePicker.Items.Add("กรุงเทพมหานคร");
            ProvincePicker.Items.Add("เชียงใหม่");
            ProvincePicker.Items.Add("ขอนแก่น");
            ProvincePicker.Items.Add("พิษณุโลก");
            ProvincePicker.Items.Add("ประจวบคีรีขันธ์");



			if (product != null)
			{
                kindPicker.SelectedItem = product.Kind;
                brandPicker.SelectedItem = product.Brand;
				VersionEntry.Text = product.Version;
				yearEntry.Text = product.Year.ToString();
                mileEntry.Text = product.Mile.ToString();
				ColorPicker.SelectedItem = product.Color;
				PhoneEntry.Text = product.Phone.ToString();
                PriceEntry.Text = product.Price.ToString();
				DetailEditor.Text = product.Detail;
                ProvincePicker.SelectedItem = product.Province;
				


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
                    product.Kind = kindPicker.SelectedItem.ToString();
                    product.Brand = brandPicker.SelectedItem.ToString();
					product.Version = VersionEntry.Text;
                    product.Year = int.Parse(yearEntry.Text);
                    product.Mile = int.Parse(mileEntry.Text);
					product.Color = ColorPicker.SelectedItem.ToString();
                    product.Phone = int.Parse(PhoneEntry.Text);
                    product.Price = int.Parse(PriceEntry.Text);
					product.Detail = DetailEditor.Text;
                    product.Province = ProvincePicker.SelectedItem.ToString();
					
					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
				}
				else
				{

					product.Kind = kindPicker.SelectedItem.ToString();
					product.Brand = brandPicker.SelectedItem.ToString();
					product.Version = VersionEntry.Text;
                    product.Year = int.Parse(yearEntry.Text);
                    product.Mile = int.Parse(mileEntry.Text);
					product.Color = ColorPicker.SelectedItem.ToString();
					product.Phone = int.Parse(PhoneEntry.Text);
                    product.Price = int.Parse(PriceEntry.Text);
					product.Detail = DetailEditor.Text;
					product.Province = ProvincePicker.SelectedItem.ToString();
					
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
