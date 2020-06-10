# GeoGebra u C#
C# app koja imitira GeoGebru

# Klasa Matrica

- **Atributi**

Jedini atribut je float [,] mat koji predstavlja datu matricu.

- **Konstruktori**

Prazan konstruktor i konstruktor na osnovu atributa.

- **Svojstva**

Svojstva N i M koja vraćaju dužinu i širinu matrice i svojstvo Mat kojim može da se postavi matrica i koje može da vrati matricu.

- **Operatori**

Operator \* za množenje matrica.

**Klasa Tačka**

Ova klasa nasleđuje klasu Matrica.

- **Atributi**

Imamo static atribut NT koji označava trenutni broj napravljenih tačaka i atribute string ime i Color boja.

- **Konstruktori**

Konstruktor kopije, prazan konstruktor, konstruktor na osnovu atributa.

- **Svojstva**

Svojstvo za vraćanje imena, boje i x i y koordinata tačke i svojstvo uPointF koje vraća tačku tipa PointF.

- **Metode**

void Crtaj(grafika, koeficijent za razmeru, koordinatni početak) - za crtanje tačke float Rastojanje(Tacka T) - rastojanje od druge tačkefloat Rastojanje(Prava p) - rastojanje od pravefloat Rastojanje(Duz d) - rastojanje od dužifloat Rastojanje(Krug k) - rastojanje od centra kruga

Pravili smo metode Najblizi koje vraćaju najbliži objekat datoj tački (indeks tog objekta u odgovarajućem nizu). Ovo smo napravili zato što hoćemo da označimo objekat ako neko klikne u njegovoj neposrednoj okolini, da korisnik ne mora da pritisne tačno na taj piksel gde je objekat, nego selektuje objekat najbliži tački na koju je kliknuo mišem.

int Najblizi(niz pravih u kome su sve prave koje su napravljene) - najbliža prava datoj tački int Najblizi(niz duži) - najbliža duž datoj tački int Najblizi(niz krugova) - najbliži krug datoj tački int Najblizi(niz tačaka) - najbliža tačka datoj tački

Sada imamo niz klasa koje nasleđuju klasu Matrica. One predstavljaju matrice izometrijskih transformacija. Kada hoćemo da npr. transliramo tačku, njenu sliku dobijemo kad pomnožimo matricu te tačke sa matricom translacije. Zato smo i tačke i izometrije pravili u formi matrica. U sledeće 4 klase imamo samo jedan konstruktor koji pravi matricu te izometrije. Imamo klase: **Translacija, Rotacija, Homotetija** ​ i​ **Refleksija** ​ .​

# Klasa Prava

- **Atributi**

Imamo static atribut NP koji označava broj napravljenih prava i atribute float k i float n (pravu predstavljamo kao y=k\*x+n) i string ime.

- **Konstruktori**

Konstruktor sa dve tačke i imenom i konstruktor na osnovu atributa.

- **Svojstva**

Svojstva za vraćanje koeficijenta, preseka sa y osom i imena.

- **Metode**

void Crtaj(grafika, koeficijent za razmeru, koordinatni početak, niz objekata, vrsta objekta, RadioButton showhide, pictureBox) - metod za crtanje prave bool Pripada(Tacka T) - da li tačka pripada datoj pravoj

Prava Normala(Tacka T) - normala iz neke tačke na datu pravuPrava Paralela(Tacka T) - prava paralelna datoj pravoj u nekoj tački

double Ugao(Prava p) i double Ugao(Prava p) - ugao između date prave i druge prave, odnosno, duži

Prava SimetralaUgla(Prava p) - simetrala ugla koje obrazuju data prava i druga prava

Prava SimetralaUgla(Duz d) - simetrala ugla koje obrazuju data prava i duž

Zatim imamo metode Presek koje vraćaju tip Tacka, odnosno tačku preseka date prave sa duži, drugom pravom ili krugom.

Poslednje metode su preslikavanja date prave izometrijskim transformacijama.

**Klasa Duz**

Duž je dosta slična pravoj, pa smo napravili da nasleđuje klasu Prava.

- **Atributi**

Imamo static atribut ND koji označava broj napravljenih duži i atribute Tacka A i Tacka B koji su krajevi duži.

- **Konstruktori**

Konstruktor na osnovu atributa.

- **Svojstva**

Svojstva Prva Tacka1 i Tacka2 koja vraćaju prvu i drugu tačku duži.

- **Metode**

Nove metode kojih nema kod Prave su:Prava Simetrala() - simetrala date duži

void PravilanMnogougao(broj temena, niz tačaka, niz duži, niz objekata) - pravi pravilan mnogougao sa n stranica, čija je jedna stranica data duž. Takođe, nove dobijene tačke i duži dodaje u odgovarajući niz.

# Klasa Krug

- **Atributi**

Imamo static atribut NK koji označava broj napravljenih krugova. Tacka C je centar kruga, double r poluprečnik i imamo još string ime.

- **Konstruktori**

Konstruktor na osnovu atributa, konstruktor od 3 tačke(treba nam za konstrukciju 3 tačke na krugu), konstruktor od dve tačke (centar i tačka na krugu) i konstruktor od duži i tačke (šestar).

- **Svojstva**

Svojstva za vraćanje centra, poluprečnika i imena.

- **Metode**

Imamo metode za crtanje kruga, da li tačka pripada krugu, preseke kruga sa drugim objektima, izometrijske transformacije.

Ono što je novo za krug su tangente iz tačke na krug i inverzija.

void Tangente(Tacka T, niz prava, niz objekata) - ako tačka pripada krugu, vraća jednu tangentu, ako ne pripada, napravi obe, ako je unutar kruga ne radi ništa.

U inverzijama imamo 5 funkcija: Inverzija tačke u odnosu na krug, što je druga tačka;

Inverzija prave u odnosu na krug, ako centar kruga pripada pravoj, što vraća pravu;

Inverziju prave u odnosu na krug, ako prava ne sadrži centar kruga, što vraća krug; Inverziju kruga kada krug ne sadrži centar inverzije, što je novi krug i Inverziju kruga kada on sadrži centar, što daje novu pravu.

# FORMA (APLIKACIJA)

- **Inicijalizacija**

Postavljanje static atributa (koordinatni pocetak, velicinu sistema-konstantu k). Inicijalizujemo niz objekata (svi zajedno), niz tacaka, pravih, duzi i krugova. Prilikom dodavanja svakog objekta za upotrebu, smestamo ga u njemu odgovarajuci niz, i registrujemo promene povecanjem broja objekata u svakom nizu.

- **Promenljive**

Uvodimo sve promenljive koje ce nam biti potrebne, definisemo malopre pomenute nizove.

- **Metode**

Formiramo pozivanje svih metoda iz klasa, u vezi sa crtanjem: Reset, ponnistava stanje crtanja - time smo zavrsili konstrukciju jednog objekta, postavlja vrednosti promenljivih j1,j2,j3 na 0, vraca pocetnu boju tacki; Undo, vracanje za jedan korak unazad (svaki korak se registruje); Oznacavanje, dajemo ime objektima koje uvodimo; Najblizi, za datu tacku nalazi objekat iz niza objekata koji mu je najblizi, pri cemu je rastojanje objekata definisano u klasama; Dodaj, dodaje objekte u odgovarajuce nizove.

- **Paint**

Tacke koje smo uveli klikom na povrsinu bojimo plavom, a tacke dobijene kao presek objekata (npr. presek dve prave) bojimo crnom bojom. U stanju crtanja oblika, kad izaberemo tacku za koriscenje, ona postaje zelena.

- **Radio Buttons**

Uvodimo potrebne objekte klase Radio Button da bismo izabrali opciju koju zelimo kad crtamo (selektovanjem odgovarajuceg Radio Buttona izvrsavamo zeljeni potez).

- **Zoom**

Uvelicava (zoom in) ili umanjuje (zoom out) koeficijent k, sto rezultuje promeu velicina oblika koje smo nacrtali.

- **Obrisi sve**

Brisemo ceo sadrzaj, cistimo povrsinu za crtanje.

- **Undo**

Klikom na dugme, poziva metodu Undo.

- **Pomeraj**

Translira povrsinu za crtanje.

- **Mouse click**

# MOUSE CLICK​ (uputstvo za konstrukciju objekata)

- **Tacka**

Klikom na povrsinu, konstruisemo novu tacku, dodajemo u niz objekata i tacaka i bojimo je plavom bojom

- **Duz**

Klikom na dve tacke i izborom opcije Crtanje Duzi, formiramo novu duz koju dodajemo u niz objekata i duzi

- **Prava**

Klikom na dve tacke i izborom opcije Crtanje Prave, formiramo novu duz koju dodajemo u niz objekata i pravih

- **Paralela / Normala**

Klikom na tacku i pravu konstruisemo paralelu, odnosno normalu kroz tu tacku na tu pravu, nakon cega je dodajemo u niz pravih i objekata

- **Simetrala ugla**

Biramo dve prave i teme ugla, datom opcijom konstruisemo simetralu tog ugla, dodajemo je u niz pravih i objekata

- **Simetrala duzi**

Izborom dveju tacaka i date opcije konstruisemo simetralu duzi od te dve tacke, dodajemo je u niz pravih i objekata

- **Mnogougao**

Izborom duzi i ove opcije, unosimo broj temena koje ce imati nas mnogougao. Svako sledece teme konstruise se kao rotacija preposlednjeg oko poslednjeg za ugao (n-2)\*pi/n, dobija se pravilni n-tougao

- **Tangente**

Izborom tacke i kruga, uz ovu opciju konstruisemo dve tangente iz ove tacke na dati krug, ako se ona ne nalazi unutar kruga. Te dve prave se dodaju u niz pravih i objekata.

- **Presek**

Izborom dva objekta (prava/duz/krug), konstruisemo tacke koje su u preseku njih

- **Duz date duzine**

Izborom tacke i unosom zeljene duzine, konstruisemo duz te duzine, paralelnu sa x-osom koordinatnog sistema

- **Ugao date velicine**

Izborom temena ugla, kraka i unosom velicine ugla konstruise se drugi krak ugla

- **Merenje duzi/ugla**

Izborom neke od ovih opcija izracunavamo i ispisujemo njegovu velicinu

# Konstrukcije krugova

- **Centar i tacka na krugu**

Biramo centar kruga i tacku na njemu, cime konstruisemo zeljeni krug

- **Centar i poluprecnik**

Biramo centar i unosimo poluprecnik zeljenog kruga, cime se on konstruise

- **Tri tacke**

Izborom tri tacke konstruisemo krug kroz njih ovom opcijom

- **Nalazenje centra kruga**

Izborom odredjenog kruga, konstruise se tacka koja je njegov centar

# Transformacije

- **Homotetija**

Izborom centra homotetije i unosenjem koeficijenta, konstruisemo objekat dobijen datom homotetijom i smestamo u odredjene nizove

- **Translacija**

Izborom dveju tacaka, izabrani objekat transliramo za vektor dobijen tim tackama.

- **Refleksija**

Izborom ose refleksije i datog objekta, ovom opcijom preslikavamo dati objekat preko te prave

- **Rotacija**

Izborom centra rotacije, klikom na tacku koju rotiramo i unosenjem ugla rotacije (u stepenima), konstruisemo zarotiranu tacku

- **Inverzija**

Izborom tacke i kruga, uz ovu opciju konstruisemo inverznu sliku tacke u odnosu na dati krug (anaizom da li je u krugu, van njega ili na kruznici)

Petar Samardžić | Momčilo Mrkaić | Pavle Pakalović | Miloš Milićev
