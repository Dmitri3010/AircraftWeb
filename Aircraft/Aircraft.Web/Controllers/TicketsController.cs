using System;
using Aircraft.Web.Core.Models;
using DB = PN.Storage.EF.SimpleRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;

namespace Aircraft.Web.Controllers
{
    [Route("api/[controller]")]
    public class TicketsController : BaseController
    {
        [HttpGet("GetUserTicket")]
        public ActionResult GetUserTicket(string userId)
        {
            return string.IsNullOrWhiteSpace(userId)
                ? (ActionResult) BadRequest()
                : Ok(DB.Get<Ticket>().Where(p => p.UserId == userId));
        }

        [HttpPost("AddOrUpdate")]
        public ActionResult AddOrUpdate([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }

            var tempTicket = new Ticket
            {
                UserId = ticket.UserId,
                FlightTime = ticket.FlightTime,
                ArrivivalCity = ticket.ArrivivalCity,
                Seat = ticket.Seat,
                FromCity = ticket.FromCity,
                OrderTime = DateTimeOffset.Now.ToString()

            };
            var emailMessage = new MimeMessage();
 
            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "login@yandex.ru"));
            emailMessage.To.Add(new MailboxAddress("", ticket.Email));
            emailMessage.Subject = "New ticket";
            emailMessage.Body = new TextPart("dssdsd")
            
            {
                Text = $"You buy a ticket from {tempTicket.FromCity} to {tempTicket.ArrivivalCity}"
            };
             
            using (var client = new SmtpClient())
            {
                 client.ConnectAsync("smtp.yandex.ru", 25, false);
                 client.AuthenticateAsync("dimitri.lol@yandex.ru", "Azaza7788");
                 client.SendAsync(emailMessage);
 
                 client.DisconnectAsync(true);
            }

            DB.Upsert(tempTicket);
            return Ok();
        }

        [HttpGet("Delete")]
        public ActionResult Delete(string ticketId)
        {
            if (string.IsNullOrWhiteSpace(ticketId))
            {
                return BadRequest();
            }

            DB.Delete<Ticket>(p => p.Id.ToString() == ticketId);
            return Ok();
        }

        [HttpGet("GetAllTickets")]
        public ActionResult GetAllTickets()
        {
            return Ok(DB.Get<Ticket>());
        }

        [HttpGet("GetTicket")]
        public ActionResult GetTicket(string ticketId)
        {
            return string.IsNullOrWhiteSpace(ticketId)
                ? (ActionResult) BadRequest()
                : Ok(DB.Single<Ticket>(p => p.Id.ToString() == ticketId));
        }
    }
}