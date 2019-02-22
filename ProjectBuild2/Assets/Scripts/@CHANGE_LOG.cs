/*This will be used for any and all change listing since I don't /think/ gitHub does that for us?
 * 
 * 2/17/2019 - Nathan Michell
 * Changes made:
 *      - Encumbrance now starts at 5 out of 10.
 *      - Encumbrance ticks down at a rate of (0.020 / (currentHealth + 1) every Update.
 *      - If Encumbrance or currentHealth ever hit 0, the dwarf stops moving forwards.
 *      - Gold now gives 1 unit of Encumbrance whenever picked up.
 *      - Gold now spawns more often.
 *      - mercyInvincibility added. When taking damage, mercyInvincibility will be set to 1.5 and will tick down at a rate of 0.0025 per Update
 * Proposed changes:
 *      - Add details regarding these new mechanics to the design document.
 *      - Known bug: When the dwarf stops moving forwards, they SLOWLY slide backwards.
 * 
 * 2/19/2019 - Matthew Findley
 * Changes made:
 *      - Added GameOver text when the player drops down to zero health.
 * 
 * 2/19/19 - Eric Versaw
 * Changes made:
 *      - Made the boulders spawn less frequnetly and created a variable to change the Spawn_Rate through this variable for future use 
 * 
 * 2/21/2019 - Nathan Michell
 * Changes made:
 *      - Added loads of sound effects. Taking damage, getting knocked out/stopping, picking up gold, breaking walls/boulders, and running.
 *      - Changed some variables to use deltaTime instead of very small floats.
 *      - 
 *      - 
 *      - 
 * 2/21/2019 - Eric Versaw
 * Changes made:
 *      - Added a cooldown to the pickaxe so you cannot spam it and live forever
*/
