Hämta alla användare: [HttpGet] https://localhost:44331/api/users
Hämta alla intressen som är kopplade till en specifik person: [HttpGet("{id}")]  https://localhost:44331/api/users/1
Hämta alla länkar som är kopplade till en specifik person: [HttpGet] https://localhost:44331/api/userinterest
Koppla en person till ett nytt intresse: [HttpPut("{id}")] https://localhost:44331/api/userinterest/4
Lägga in nya länkar för en specifik person och ett specifikt intresse: [HttpPost] https://localhost:44331/api/userinterest

Kommentar: På anropet "Hämta alla intressen som är kopplade till en specifik person" inkluderade jag kopplingstabellen "UserInterests" och sedan "Interests", men intressena skrivs inte ut, utan bara kopplingstabellen. Vet inte vad som är fel eftersom det finns en koppling mellan "UserInterests" och "Interests".

Jag är osäker på om jag tolkade anropet "Hämta alla länkar som är kopplade till en specifik person". Om jag gör ett anrop baserat på "UserID" får jag bara första träffen utskriven med koppling till intresse. Om ett UserID har flera intresse-kopplingar syns det inte pga "FirstOrDefaultAsync".