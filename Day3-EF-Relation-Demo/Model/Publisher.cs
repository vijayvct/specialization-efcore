using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day3_EF_Relation_Demo;

public class Publisher
{
    [Key]
    public int PubId { get; set; }
    
    [Required]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Location { get; set; }

    //Navigation Property 
    public IEnumerable<Book> Books { get; set; }
}

public class Book
{
    [Key]
    public int BkId { get; set; }
    
    [Required]
    public string Title { get; set; }

    //Foreign Key 
    [ForeignKey("Publisher")]
    public int PubId{get;set;}

    //Navigation Property
    public Publisher Publisher{get;set;}
}