﻿using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class PeopleService : Service<Person>, IPeopleService
    {
        public PeopleService(DbContext context) : base(context)
        {
        }
    }
}