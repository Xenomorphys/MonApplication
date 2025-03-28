using Microsoft.AspNetCore.Mvc;
using MonApplication.Data;
using MonApplication.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

[Route("admin/utilisateurs")]
public class AdminUtilisateurController : Controller
{
    // private readonly ILogger<AdminUtilisateurController> _logger; // Logger pour le suivi des événements
    // public AdminUtilisateurController(ILogger<AdminUtilisateurController> logger) // Injecter le logger
    // {
    //     _logger = logger;
    // }
    // _logger.LogInformation("AdminUtilisateurController initialized"); // Log l'initialisation du contrôleur
    // _logger.LogWarning("Warning: AdminUtilisateurController initialized"); // Log un avertissement
    // _logger.LogErreur("Erreur: AdminUtilisateurController initialized"); // Log une erreur

    private readonly ECommerceDbContext _context;

    // Constructeur qui injecte le contexte de base de données
    public AdminUtilisateurController(ECommerceDbContext context)
    {
        _context = context;
    }

    // Affiche la liste des utilisateurs
    [HttpGet("list")]
    public IActionResult List()
    {
        var users = _context.Utilisateur
        .Include(u => u.Role)
        .Include(u => u.Localite)
        .ToList();
        return View("AdminUtilisateur", users);
    }

    // Affiche un formulaire vide avec des valeurs par défaut pour créer un utilisateur
    [HttpGet("create")]
    public IActionResult Create()
    {
        return View(new Utilisateur
        {
            Nom = string.Empty,
            Prenom = string.Empty,
            Adresse = string.Empty,
            Email = string.Empty,
            MotDePasse = string.Empty,
            IdRole = 0,
            IdLocalite = 0,
        });
    }

    // Traite l'ajout d'un utilisateur
    [HttpPost("create")]
    public IActionResult Create(Utilisateur utilisateur)
    {
        if (!ModelState.IsValid)
        {
            return View(utilisateur);
        }

        // Hachage du mot de passe
        utilisateur.MotDePasse = BCrypt.Net.BCrypt.HashPassword(utilisateur.MotDePasse);

        // Ajout en base de données
        _context.Utilisateur.Add(utilisateur);
        _context.SaveChanges();

        return RedirectToAction("List");
    }

    // Supprime un utilisateur
    [HttpPost("delete/{id}")]
    public IActionResult Delete(int id)
    {
        var utilisateur = _context.Utilisateur.Find(id);
        if (utilisateur == null)
        {
            return NotFound();
        }

        _context.Utilisateur.Remove(utilisateur);
        _context.SaveChanges();

        return RedirectToAction("List");
    }
}