using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using ClosedXML.Excel;

using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using OnlineExamSystem.Services.Interfaces;

namespace OnlineExamSystem.Services
{
    public class ExcelImportService : IExcelImportService
    {

        private readonly MyDbContext _context;


        public ExcelImportService(MyDbContext context)
        {
            _context = context;
        }



        public async Task<string> ImportQuestions(IFormFile file, int examId)
        {

            using var stream = new MemoryStream();

            await file.CopyToAsync(stream);


            using var package = new ExcelPackage(stream);


            var worksheet = package.Workbook.Worksheets[0];


            int rowCount = worksheet.Dimension.Rows;


            for (int row = 2; row <= rowCount; row++)
            {

                var question = new Question
                {

                    QuestionText =
                    worksheet.Cells[row, 1].Value.ToString(),


                    OptionA =
                    worksheet.Cells[row, 2].Value.ToString(),


                    OptionB =
                    worksheet.Cells[row, 3].Value.ToString(),


                    OptionC =
                    worksheet.Cells[row, 4].Value.ToString(),


                    OptionD =
                    worksheet.Cells[row, 5].Value.ToString(),


                    CorrectAnswer =
                    worksheet.Cells[row, 6].Value.ToString(),


                    ExamId = examId

                };


                _context.question.Add(question);

            }


            await _context.SaveChangesAsync();
            return "Questions imported successfully";

        }

    }
}