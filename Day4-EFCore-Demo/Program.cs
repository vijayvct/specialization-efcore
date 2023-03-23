using Day4_EFCore_Demo.Data;
using Day4_EFCore_Demo.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Day4_EFCore_Demo;
class Program
{
    //Eager Loading 
    static void EagerLoading1()
    {
        var context = new MusicStoreDBContext();

        var customers = context.Customers
                        .Include(c=>c.Invoices)
                        .Where(c=>c.FirstName.StartsWith("A"));

        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}");
            foreach(var invoice in customer.Invoices)
            {
                Console.WriteLine($"\t\t{invoice.InvoiceDate} {invoice.Total}");
            }
        }
    }

    static void EagerLoading2()
    {
        var context= new MusicStoreDBContext();

        var customers = context.Customers
                       .Include(c=>c.Invoices)
                       .ThenInclude(c=>c.InvoiceLines)
                       .ThenInclude(c=>c.Track)
                       .Where(c=>c.FirstName.StartsWith("A"));

        foreach(var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}"); 
            
            foreach(var invoice in customer.Invoices)
            {
                Console.WriteLine($"\t\t{invoice.InvoiceDate} {invoice.Total}");

                foreach(var invoiceline in invoice.InvoiceLines)
                {
                    Console.WriteLine($"\t\t\t{invoiceline.TrackId} {invoiceline.UnitPrice}");
                }
            }
        }
    }

    static void ExplicitLoading()
    {
        var context = new MusicStoreDBContext();

        var tracks = context.Tracks.Take(5).ToList();

        foreach(var track in tracks)
        {
            context.Entry(track).Reference(t=>t.Album).Load();
            context.Entry(track.Album).Reference(t=>t.Artist).Load();

            Console.WriteLine($"Album = {track.Album.Title} , Track = {track.Name}, Artist = {track.Album.Artist.Name}");
        }
    }

    static void LazyLoading()
    {
        var context = new MusicStoreDBContext();

        var albums = context.Albums.Take(5).ToList();

        foreach(var album in albums)
        {
            Console.WriteLine($"{album.Title}");

            foreach(var track in album.Tracks)
            {
                Console.WriteLine($"\t\t{track.Name}");
            }
        }
    }
    static void Main(string[] args)
    {
        //EagerLoading1();
        //EagerLoading2();
        //ExplicitLoading();
        LazyLoading();
    }
}
