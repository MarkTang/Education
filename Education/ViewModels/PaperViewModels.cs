﻿using Education.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Education.ViewModels
{
    public class PaperViewModel
    {
        public List<TrueOrFalseQuestionViewModel> TrueOrFalseQuestions { get; set; }
        public List<SingleQuestionViewModel> SingleQuestions { get; set; }
        public List<MultipleQuestionViewModel> MultipleQuestions { get; set; }
        public PaperViewModel()
        {
            TrueOrFalseQuestions = new List<TrueOrFalseQuestionViewModel>();
            SingleQuestions = new List<SingleQuestionViewModel>();
            MultipleQuestions = new List<MultipleQuestionViewModel>();
        }
    }
    public abstract class QuestionViewModel
    {
        [DisplayName("题目类型")]
        public QuestionType Type { get; set; }

        [DisplayName("题目内容")]
        [Required(ErrorMessage = "请输入题目内容！")]
        public string Content { get; set; }
    }
    public class TrueOrFalseQuestionViewModel : QuestionViewModel
    {
        [DisplayName("是否正确？")]
        public bool IsCorrect { get; set; }
        public TrueOrFalseQuestionViewModel()
        {
            Type = QuestionType.判断题;
            IsCorrect = false;
        }
    }
    public class SingleQuestionViewModel : QuestionViewModel
    {
        public List<OptionViewModel> Options { get; set; }
        public int CorrectAnswer { get; set; }
        public SingleQuestionViewModel()
        {
            Type = QuestionType.单选题;
            Options = new List<OptionViewModel>();
        }
    }
    public class MultipleQuestionViewModel : QuestionViewModel
    {
        public List<MultipleOptionViewModel> Options { get; set; }
        public MultipleQuestionViewModel()
        {
            Type = QuestionType.多选题;
            Options = new List<MultipleOptionViewModel>();
        }
    }

    public class OptionViewModel
    {
        [DisplayName("选项号")]
        public OptionType OptiondId { get; set; }

        [DisplayName("选项内容")]
        [Required(ErrorMessage = "请输入选项内容！")]
        public string OptionProperty { get; set; }

    }
    public class MultipleOptionViewModel : OptionViewModel
    {
        [DisplayName("选项是否正确？")]
        public bool IsCorrect { get; set; }
    }
}