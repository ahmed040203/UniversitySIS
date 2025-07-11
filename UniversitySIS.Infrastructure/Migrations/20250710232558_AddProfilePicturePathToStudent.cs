﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversitySIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePicturePathToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicturePath",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicturePath",
                table: "Students");
        }
    }
}
