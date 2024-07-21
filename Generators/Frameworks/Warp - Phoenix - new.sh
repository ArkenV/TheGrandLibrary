git clone https://github.com/ACCOUNT/{{PROJECT}}.git
cd {{PROJECT}}
mix phx.new . --app {{PROJECT}} --no-assets --no-ecto --no-esbuild --no-html --no-live --no-tailwind --install
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