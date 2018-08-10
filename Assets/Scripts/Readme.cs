using UnityEngine;

// Only for purpose of readme.
public class Readme : MonoBehaviour
{

  /* 
    # KOD:
      * dodac obsluge kolizji pilki z swiperem?
      * dorobic obsluge tego ze pilka sie zatrzyma na floor lub wewnatrz pins settera
      * change name of ActionMaster class and name of methods in it
      * find TO_DO
      * doadac high scores
      * dodac menu 
      * dodac muzyke (zmiane muzyki)
      * dodac dzwiek uderzania w kregle
      * dodac end scenes: start, help, high scores, endgame 
      * dodac obsluge odleglosci pilki od kregli(poziom trudnosci)
      * improve view of buttons

    
    # Wygląd:
      * find better ball texture
      * po wejsciu w collider pins settera przez ball powinna sie zmienic kamera na zblizenie pinow, po pinshavesettled powinna zostac przywrocona do pilki
      * dorobic wysiegniki ustawiajace kregle, 
      * dorobic oboudowe na koncu toru
      * dorobic inne tory z animacjami
      * dorobic sciane z jakas tekstura
      * dorobic rynny
      * dodaj z prawej i lewej kolejne tory oddzielone rynienkami, na kazdym z nich kregle kotre sa zbijane przez innych i resetowane  
      * dodaj twktury do przyciskow zeby byly ladniejsze
      * dodaj texture na swipera


    # FOR BEN:
      * W pin raise u Bena powinno byc resetowanie velocity i position! zamiast eulera mozna zrobic to tez jak ja czyli zapamietujac pozycje wejsciowa,
        dzieki temu nie ma potrzeby nic zmieniania w kodzie jesli pozmieniamy ich startowa pozycje w edytorze na jakas inna
      * zamiast '(!ball.inPlay) w 'BallDragLaunch' mozna zmienic ta flage na 'is_roll_in_progress' (poki co mam to w 'PinSetter') ktora jest ustawiana przy
        ball.Lauch oraz w adimacji w dodatkowym stanie 'AnimationEnd'. Funkcje:
        RollStart()
        RollEnd()
        IsRollInProgress()
      * Kolizje mozna inaczej rozwiazac... 
      * Sprawdzenie ktore kregle stoja powinno byc dopiero w 'OnTriggerExit' w 'PinSeter', dopiero jak kula go opusci
      * Continouse dynamic mogloby byc omowione w dziale zwiazanym z pingpongiem bo ja juz tam sie spotkalem z tego typu problemem :/
      * launchVeclocity w ball jest zbedne
      * wydaje mi sie ze podnoszenie calego zbioru pinow w Renew() bedzie prowadzic do bledow(przy tidy?)
      * BTW, I found a bug where tapping the screen counts as a launch, but the ball stands still and the game can’t be completed. 
        I fixed this by adding a condition that upward swipe speed should be greater than a threshold value in order to register as a launch.
      * Tell students about unity hub
  */
}
