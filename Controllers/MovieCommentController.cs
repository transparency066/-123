﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBusinessLogic;
using MovieModel;

namespace MovieWeb.Controllers
{
    public class MovieCommentController : Controller
    {
        // GET: MovieComment
        Manager_nyx manager = new Manager_nyx();

        [HttpGet]
        public ActionResult Index()
        {
            string mid = System.Web.HttpContext.Current.Session["movieID"].ToString();
            var comments = manager.GetAllComments(mid).Select(comment => new Comment()
            {
                movieID = comment.movieID,
                userID = comment.userID,
                commentTime = comment.commentTime,
                commentContent = comment.commentContent
            }).ToList();
            return View(comments);          
        }

        [HttpPost]
        public ActionResult Index(FormCollection txt)
        {
            int commentCode = 0;
            string content = txt["PostContent"];
            DateTime time = DateTime.Now;
            string mid = System.Web.HttpContext.Current.Session["uid"].ToString();

            if (Session["uid"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            { 
                string uid = System.Web.HttpContext.Current.Session["uid"].ToString();
                if (manager.PostComment(mid, uid, time, content) > 0)
                {
                    commentCode = 1;
                    ViewBag.commentCode = 1;
                }
                else
                {
                    ViewBag.commentCode = 0;
                }
            }
            return Index();
        }
    }
}