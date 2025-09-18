# shotgunTextSpel

## Beskrivning
Ett enkelt textbaserat spel där man spelar Shotgun mot datorn.  
Spelet påminner om Sten, Sax, Påse men med någon mer regler. Matchen pågår tills någon vinner.

## Regler
- Ladda = +1 skott  
- Blocka = stoppar skott  
- Skjuta = förbrukar ett skott  
- Shotgun = kräver 3 skott och vinner direkt  

## Projektstruktur
- Program.cs = Huvudfilen som startar spelet och visar menyn
- GameLogik.cs = Innehåller spelreglerna och styr matchen
- Player.cs = Basklass för både människa och dator
- HumanPlayer.cs = Klass som tar hand om spelarens inmatning via terminalen
- BotPlayer.cs = Klass som styr datorns val med slumpgenerator
- Move.cs = Enum som definierar alla möjliga drag 
- .gitignore = Säkerställer att tillfälliga filer och mappar (bin/ och obj/) inte laddas upp till GitHub  

## Arbetssätt
- Skapat ett GitHub-repo för spelet.  
- Använt GitHub Projects för att planera arbetet i steg, och enklare se vad som behöver göras.  
- Delat upp koden i flera filer(Klasser) för tydlighet.  
- Jobbat objektorienterat med klasser och arv.  
- Använt Random för datorns val.  
- Lagt till en fördröjning på 3 sekunder vid datorns drag för att kännas mer verkligt.   

## Hur spelet fungerar
- Spelaren får välja mellan tillgängliga drag via meny i terminalen.  
- Datorn väljer sitt drag slumpmässigt.  
- Resultatet av rundan skrivs ut och antal skott uppdateras.  
- Spelet fortsätter tills någon vinner.  
- Meny finns för att starta om eller avsluta spelet.  
