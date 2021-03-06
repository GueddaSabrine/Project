<?php
//On demande au server de demarrer une session
session_start();

// On teste si le user a effectuer une saisie
    if (!empty($_POST['email'])){
        // on crée les variables
        $email = $_POST['email'];
        $mdp = $_POST['mdp'];

    // On met les informations de connexion en session
        //on récupère la valeur de l'email
        $_SESSION['email'] = $email;
        //on récupère la valeur du mdp
        $_SESSION['mdp'] = $mdp;

    #On est redirigé vers la page de conversion
    header("Location:converter.php");
    exit();
    }
?>

<!doctype html>
<html lang="en">
    <head>
        <title>Login Page</title>
        <!-- Required meta tags -->
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

        <!-- Bootstrap CSS -->
        <link rel="stylesheet" type="text/css" href="../public/css/bootstrap.min.css"/>
        <link rel="stylesheet" type="text/css" href="../public/css/style.css"/>
    </head>

<body>
    <div class="container">
        <header>
            projet converter
        </header>
        <main>
            <div class="form-header">
                login form
            </div>
            <div class="appForm">
                <form method="post">
                    <div class="form-group">
                        <label for="email">Email</label>
                        <input type="email" class="form-control" placeholder="Entrez 'user@domain' comme identifiant"
                               id="email"
                               required name="email">
                    </div>
                    <div class="form-group">
                        <label for="mdp">Mot de passe</label>
                        <input type="password" class="form-control" placeholder="Taper 'password'  comme mot de passe"
                               id="mdp" name="mdp">
                    </div>

                    <button type="submit" class="btn btn-success">Valider</button>
                    <button type="reset" class="btn btn-danger float-right">Effacer</button>
                </form>
            </div>
        </main>
    </div>

        <!-- Optional JavaScript -->
        <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" defer></script>
    <script src="../public/js/bootstrap.min.js" defer ></script>
</body>
</html>
