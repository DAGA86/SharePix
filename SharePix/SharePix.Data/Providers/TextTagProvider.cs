﻿using Microsoft.EntityFrameworkCore;
using SharePix.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharePix.Data.Providers
{
    public class TextTagProvider
    {
        private Contexts.DatabaseContext _dbContext;

        public TextTagProvider(Contexts.DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TextTag Create(TextTag tag)
        {
            _dbContext.TextTags.Add(tag);
            _dbContext.SaveChanges();

            return tag;
        }

        public bool Delete(int id)
        {
            TextTag? textTagToDelete = _dbContext.TextTags.FirstOrDefault(x => x.Id == id);
            if (textTagToDelete != null)
            {
                _dbContext.TextTags.Remove(textTagToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
