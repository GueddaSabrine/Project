<?php
    session_start();
    //$_SESSION['celsius']= 1;
    //$celsius = $_SESSION['celsius'];

    if ( !empty($_SESSION['email']) ){   // est-ce que la session n'est pas vide et contient un email ?
        $email = $_SESSION['email'];
        $mdp = $_SESSION['mdp'];
        $celsius = 0;
        $fahren = 32;


        //si le login (email) et mdp ne correspondent pas, on est redirigé sur la page de login
        if ( $mdp !== "password" || ( strtolower($email) !== strtolower("user@domain") ) ) {
            #on est redirigé vers la page de login
            header("Location:login.php");
            exit();  // arrêt d'exécution du code
        }
    }

    if ( !empty($_POST['celsius']) ){

        $celsius = (float)$_POST['celsius'];
        //var_dump($celsius);
        //var_dump($_POST);
        //var_dump((float)$_POST['celsius']);

        if (is_numeric($celsius)){
            $fahren = $celsius * 9/5 + 32;
            //var_dump($fahren);
           // var_dump($celsius);
        } elseif (empty($_POST['celsius'])){
            $fahren = 32;
        }
    }

?>

<!doctype html>
<html lang="en">
<head>
    <title>Converter Page</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" type="text/css" href="../public/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../public/css/style.css"/>
</head>
<body>

<div class="container">
    <header> Convertir °C en Fahrenheit </header>
    <main>
        <div class="form-header">
            Coverter form
        </div>
        <div class="appForm">
            <form method="post">
                <div class="form-group">
                    <label for="celsius">Celsius</label>
                    <input class="form-control" placeholder="Entrez votre valeur en °C"
                           id="celsius"
                            name="celsius">
                </div>

                <button type="submit" class="btn btn-success">Valider</button>
                <button type="reset" class="btn btn-danger float-right">Effacer</button>
            </form>
        </div>

        <div id="msg">
            <?php
            //var_dump($celsius);
            //var_dump($fahren);

                if (is_numeric($celsius) ){
                    echo ("<div id='resultat' >$celsius °C = $fahren °F</div>");
                } elseif ( !(is_numeric($celsius) && !empty($celsius) ) ) {
                    echo "<div id='erreur'>Saisie erronée</div>";
                }
            ?>
        </div>

    </main>
</div>

    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script defer src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script defer src="../public/js/bootstrap.min.js"  ></script>
    <script defer src="../public/js/scriptConverter.js"></script>
</body>
</html>


