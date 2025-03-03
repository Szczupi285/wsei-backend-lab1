﻿using BackendLab01;

namespace WebApi.DTO
{
    public class QuizDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<QuizItemDto> Options { get; set; }

        public static QuizDTO Of(Quiz quiz)
        {
            return new QuizDTO
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Options = quiz.Items.Select(QuizItemDto.Of).ToList(),
            };
        }

    }
}
