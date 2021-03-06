//PARTIE1
let scoresGlobals = [0, 0];
let scoreEnCours = 0;
let joueurActif = 1;
let jouer = true;

//PARTIE2
initiliseLeJeu();

//PARTIE3
let btnLancezLeDe = document.querySelector(`.btn-lancer`);
btnLancezLeDe.addEventListener('click', () =>{

    if (jouer){
        let de = Math.floor(Math.random() * 6) + 1;
        let domDe = document.querySelector('.de');
        domDe.style.display = 'block';
        domDe.src = `resources/images/de-${de}.png`;

        if (de !== 1){
            scoreEnCours += de;
            document.getElementById(`encours-${joueurActif}`).textContent = scoreEnCours;
        } else{
            joueurSuivant()
        }
    }
});

//PARTIE4
let btnCommutez = document.querySelector('.btn-commuter');
btnCommutez.addEventListener('click', () => {

    if (jouer){
        scoresGlobals[joueurActif - 1] += scoreEnCours;
        document.getElementById(`score-${joueurActif}`).textContent=scoresGlobals[joueurActif-1];

        if (scoresGlobals[joueurActif - 1] >= 100) {
            document.getElementById(`nom-${joueurActif}`).textContent = 'Bravo !!!';
            document.querySelector('.de').style.display = 'none';
            document.querySelector(`.joueur-${joueurActif}-panel`).classList.add('vainqueur');
            document.querySelector(`.joueur-${joueurActif}-panel`).classList.remove('active');
        } else {
            joueurSuivant()
        }
    }
});

//PARTIE5
function joueurSuivant() {
    joueurActif === 1 ? joueurActif = 2 : joueurActif = 1;
    scoreEnCours = 0;
    document.getElementById(`encours-${joueurActif}`).textContent = '0';
    document.querySelector('.joueur-1-panel').classList.toggle('active');
    document.querySelector('.joueur-2-panel').classList.toggle('active');
    document.querySelector('.de').style.display = 'none';
}

//PARTIE6
let btnNouveauJeu = document.querySelector('.btn-nouveau');
btnNouveauJeu.addEventListener('click',() => {
    initiliseLeJeu();
});

//PARTIE7
function initiliseLeJeu() {
    scoresGlobals = [0, 0];
    scoreEnCours = 0;
    joueurActif = 1;

    document.querySelector('.de').style.display = 'none';
    document.getElementById('score-1').textContent = '0';
    document.getElementById('score-2').textContent = '0';
    document.getElementById('encours-1').textContent = '0';
    document.getElementById('encours-2').textContent = '0';
    document.getElementById('nom-1').textContent = 'Joueur 1';
    document.getElementById('nom-2').textContent = 'Joueur 2';
    document.querySelector('.joueur-1-panel').classList.remove('vainqueur');
    document.querySelector('.joueur-2-panel').classList.remove('vainqueur');
    document.querySelector('.joueur-2-panel').classList.remove('active');
    document.querySelector('.joueur-1-panel').classList.add('active');
}

//////////////////////////////////////////////////////////////////
