# Bird Box Kanban

Built to replace a workshop whiteboard that was often obscured by tools, this is a proposed solution to enable the Bird Box Building Team at the Hawk Conservancy Trust communicate and manage the different types of nest boxes needed to support their conservation projects.

![Screenshot](HCTKanban/wwwroot/images/screenshot.png)

The web app is built to be usable on small smartphone screens in the workshop or in the field. Deliberately lightweight with no use of bootstrap, jquery or fontawesome libraries.  
The [Drag-Drop-Touch-Js](https://github.com/drag-drop-touch-js/dragdroptouch) polyfill makes the vanilla js drag and drop code touchscreen compatible.
C# .NET Core with Entity Framework connects to a MySQL database using the Pomelo package to lower costs. 
Simple authentication to reduce friction with users  
To do:  
- Add ability for team leader to display a custom message
- Consider alternative way to display large numbers of Barn Owl Boxes in the Todo pane
