git clone https://github.com/ACCOUNT/{{PROJECT}}.git
cd {{PROJECT}}
ng n {{PROJECT}} --new-project-root=. --routing -g --ssr --style=scss
ng add @angular/pwa --skip-confirmation
ng add @angular/elements --skip-confirmation
ng add @ngrx/store --skip-confirmation
#ng add @oktadev/schematics --skip-confirmation
npm install -D tailwindcss postcss autoprefixer
npx tailwindcss init
echo "/** @type {import('tailwindcss').Config} */
module.exports =
{
  content:
  [
    './src/**/*.{html,ts}'
  ],

  theme:
  {
    extend: {}
  },

  plugins: []
}" > tailwind.config.js
echo "@tailwind base;
@tailwind utilities;
@tailwind components;" > ./src/styles.scss
echo "root = true

[*]
charset = utf-8
indent_size = 2
indent_style = space
spelling_language = en-US
insert_final_newline = false
trim_trailing_whitespace = true

[*.ts]
quote_type = single

[*.md]
max_line_length = off" > .editorconfig
code .