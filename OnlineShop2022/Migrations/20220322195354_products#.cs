using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop2022.Migrations
{
    public partial class products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b9af34-a133-43e2-8dd2-aef04ddb2b8c",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOwN0FVfEvsrJMxVOVF+lDqhkvzW8ASEHWP/J1VjBYp02LzuWCNOhrWEGGbDy9ks7Q==", "47eccc4c-de67-4611-9bb8-863f01ee8937" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27b9af34-a133-43e2-8dd2-aef04ddb2b8c",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEAHYWEpEly8p1Yx0xq4yWUgY2qThUJfyaYx+FfguzR87cloVoSu1bSYjx+hf7M4rwg==", "1bfbbd2a-ec34-4b1f-9961-0c0331fec22f" });
        }
    }
}
