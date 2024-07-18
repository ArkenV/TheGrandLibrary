# Handy Utilities — Utilidades Útiles

This is a collection of CLI tools I've either made or come across to ramp up your productivity. These should work on any Unix-like OS, including MacOS, but I figure most users will be on Linux.

Esta es una colección de herramientas de línea de comandos (CLI) que he creado o encontrado para aumentar tu productividad. Estas deberían funcionar en cualquier sistema operativo similar a Unix, incluyendo MacOS, pero supongo que la mayoría de los usuarios estarán en Linux.

## The GD Collection — La Colección GD

Have you ever tried to `cd` into a directory that didn't exist; then become irate when you discovered `cd` doesn't provide a flag for filling in missing directories along the path? I did. More than once, I might add. Enough to have one day shouted, "Change directory, god dammit!" `cd`... `gd`... The elegance in their symmetry had not been lost on me. "What a convenient command that would make," I thought to myself. "A forceful, empowering command that simply obeyed; no questions asked." Oh, would that such a thing existed... so I made it. I went into my `~/.bashrc` file and typed up a new command that would just do what I told it to. It was now too easy to wonder how else I could make my life easier. The first answer was obvious. I didn't want to edit my `~/.bashrc` file every time I wanted to add a new command, so I went in one last time and added a command which would add commands for me. Carrying on with the `gd` theme was just too tempting at this point.

¿Alguna vez has intentado usar `cd` para entrar en un directorio que no existía; y luego te has irritado al descubrir que cd no proporciona una opción para crear los directorios faltantes en la ruta? Yo sí. Más de una vez, debo añadir. Suficiente como para haber gritado un día, “¡Cambia de directorio, god dammit!” `cd`… `gd`… La elegancia en su simetría no pasó desapercibida para mí. “Qué comando tan conveniente sería”, pensé. “Un comando enérgico y empoderador que simplemente obedeciera; sin preguntas.” Oh, si tal cosa existiera… así que lo hice. Fui a mi archivo `~/.bashrc` y escribí un nuevo comando que simplemente hiciera lo que le dijera. Ahora era demasiado fácil preguntarse cómo más podría hacer mi vida más fácil. La primera respuesta era obvia. No quería editar mi archivo `~/.bashrc` cada vez que quisiera agregar un nuevo comando, así que entré una última vez y añadí un comando que añadiría comandos por mí. Continuar con el tema `gd` era demasiado tentador en este punto.

## Replacements — Reemplazos

There are staples everyone learns when beginning to use the command line. `ls`, `cat`, `grep`, etc. These are indispensable, but not perfect. Various tools have been made to augment these time-tested legends and you're missing out by not using them. Check them out and consider creating a alias if you choose to adopt any of them.

Hay comandos básicos que todos aprenden al comenzar a usar la línea de comandos: `ls`, `cat`, `grep`, etc. Estos son indispensables, pero no perfectos. Se han creado varias herramientas para mejorar estas leyendas probadas por el tiempo y te estás perdiendo de mucho si no las usas. Échales un vistazo y considera crear un alias si decides adoptar alguno de ellos.

| New Command | Replaces | Usage Examples |
|-------------|----------|----------------|
| `exa` | `ls` | - `exa` (list files)<br>- `exa -l` (detailed list)<br>- `exa -T` (tree view) |
| `bat` | `cat` | - `bat file.txt` (view file with syntax highlighting)<br>- `bat -n file.txt` (show line numbers)<br>- `bat -A file.txt` (show non-printable characters) |
| `ripgrep` (`rg`) | `grep` | - `rg pattern file.txt` (search for pattern in file)<br>- `rg -i pattern` (case-insensitive search)<br>- `rg -w word` (search for whole words) |
| `fzf` | N/A (fuzzy finder) | - `find . \| fzf` (fuzzy find files)<br>- `history \| fzf` (search command history)<br>- `kill -9 $(ps aux \| fzf \| awk '{print $2}')` (fuzzy process killer) |
| `zoxide` | `cd` | - `z directory` (jump to frequently used directory)<br>- `zi` (interactive directory jump)<br>- `z -` (go to previous directory) |
| `entr` | N/A (file watcher) | - `ls *.js \| entr node script.js` (run script when files change)<br>- `find . -name '*.py' \| entr pytest` (run tests when Python files change)<br>- `echo file.txt \| entr mail -s "File changed" user@example.com` (send email on file change) |
| `mc` | N/A (file manager) | - `mc` (launch Midnight Commander)<br>- `mc -b` (launch in black and white mode)<br>- `mc /path/to/directory` (open specific directory) |
| `screen` | N/A (terminal multiplexer) | - `screen` (start a screen session)<br>- `screen -r` (reattach to a detached session)<br>- `Ctrl-a d` (detach from current session) |
| `bind` | N/A (DNS tool) | - `bind -v` (check BIND version)<br>- `bind example.com` (query DNS for example.com)<br>- `bind -x 192.168.1.1` (reverse DNS lookup) |
| `htop` | `top` | - `htop` (interactive process viewer)<br>- `htop -u username` (show only user's processes)<br>- `htop -s PERCENT_CPU` (sort by CPU usage) |
| `tldr` | `man` | - `tldr tar` (show simplified tar manual)<br>- `tldr --update` (update tldr pages)<br>- `tldr -p linux ls` (show Linux-specific ls page) |
| `git-delta` | `diff` | - `git diff \| delta` (improved git diff output)<br>- `delta file1 file2` (compare two files)<br>- `git config --global core.pager delta` (set delta as default pager for git) |