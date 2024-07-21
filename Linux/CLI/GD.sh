# New command, goddammit!
echo 'ncgd ()
{
  echo "$1" >> ~/.bashrc && source ~/.bashrc
}' >> ~/.bashrc && source ~/.bashrc

# Change directory, goddammit!
ncgd 'cdgd ()
{
  mkdir -p "$1" && cd "$1"
}'

# New alias, goddammit!
ncgd 'nagd ()
{
  ncgd "alias $1=$2"
}'

# New export, goddammit!
ncgd 'negd ()
{
  ncgd "export $1=$2"
}'

# New path, goddammit!
ncgd 'npgd ()
{
  if [ -z "$1" ]; then
    negd "PATH" "\"$(pwd):\$PATH\""
  else
    negd "PATH" "\"$1:\$PATH\""
  fi
}'