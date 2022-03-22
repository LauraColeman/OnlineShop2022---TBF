using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop2022.Migrations
{
    public partial class productsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b9af34-a133-43e2-8dd2-aef04ddb2b8c",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOf5aOjCb4a4CbwHfvYmwfLTeddQegrp1/J4uijKSp7MUsTe+Z6Eqp5765GhafWZ4A==", "7400a398-97ea-45c0-bf38-77aea4b123fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b9af34-a133-43e2-8dd2-aef04ddb2b8c",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOwN0FVfEvsrJMxVOVF+lDqhkvzW8ASEHWP/J1VjBYp02LzuWCNOhrWEGGbDy9ks7Q==", "47eccc4c-de67-4611-9bb8-863f01ee8937" });
        }
    }
}
