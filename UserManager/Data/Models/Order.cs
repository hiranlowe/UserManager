﻿namespace UserManager.Data.Models;
public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Product { get; set; }
    public decimal Price { get; set; }
    public User User { get; set; }
}