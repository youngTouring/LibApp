using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LibApp.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DiscountRate { get; set; }
    }
}