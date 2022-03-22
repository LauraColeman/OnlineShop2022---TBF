using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop2022.Migrations
{
    public partial class productsRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b9af34-a133-43e2-8dd2-aef04ddb2b8c",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJlUqdHXaOKpF4HPrWVpchxwBbMNMRTz7FeWpkdmPbWW7+v+ArHI6YT3txJUpND5GA==", "60d7f4c3-406f-4729-8c51-ec5b92a7e243" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b9af34-a133-43e2-8dd2-aef04ddb2b8c",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOf5aOjCb4a4CbwHfvYmwfLTeddQegrp1/J4uijKSp7MUsTe+Z6Eqp5765GhafWZ4A==", "7400a398-97ea-45c0-bf38-77aea4b123fa" });
        }
    }
}
