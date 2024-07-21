package main

import
(
  `io`
  `os`
  `fmt`
  `time`
  `errors`
  `regexp`
  `unsafe`
  `os/exec`
  `runtime`
  `strings`
  `syscall`
  `io/ioutil`
  `path/filepath`
)

func main() {
  projectType := ""
  currentDirectory, err := os.Getwd()

  check(err)

  switch os.Args[1] {
    case "flutter":
      projectType = "nma"
      check(exec.Command("flutter", "upgrade").Run())
      check(exec.Command("flutter", "create", projectType).Run())
      check(os.Chdir(projectType))
      SetupActions(projectType, "")
      check(os.Mkdir("lib\\models", 0666))
      check(os.Mkdir("lib\\widgets", 0666))
      check(os.Mkdir("lib\\screens", 0666))
      check(os.Mkdir("assets", 0666))
      check(os.Mkdir("assets\\fonts", 0666))
      check(os.Mkdir("assets\\audio", 0666))
      check(os.Mkdir("assets\\images", 0666))
      check(os.Mkdir("assets\\documents", 0666))
      check(copyToClipboard(UpdateReadMe(projectType)))
      check(os.Chdir(currentDirectory))
    case "phoenix":
      projectType = "api"
      apiArgs := []string{"phx.new", projectType, "--no-live", "--no-html", "--no-assets", "--no-ecto", "--install"}

      switch os.Args[2] {
        case "mailer":
        case "nomailer": apiArgs = append(apiArgs, "--no-mailer")
        default: panic(errors.New("in-valid mail arg"))
      }

      check(makeCommandInteractive(exec.Command("mix", "local.hex")).Run())
      check(makeCommandInteractive(exec.Command("mix", "archive.install", "hex", "phx_new")).Run())
      check(makeCommandInteractive(exec.Command("mix", apiArgs...)).Run())
      check(os.Chdir(projectType))
      check(CopyFile("ProjectSettings\\CICD\\elixir_buildpack.config", "elixir_buildpack.config"))
      check(CopyFile("ProjectSettings\\CICD\\phoenix_static_buildpack.config", "phoenix_static_buildpack.config"))
      SetupActions(projectType, "null")
      check(os.Mkdir("assets", 0666))
      check(os.Mkdir("assets\\audio", 0666))
      check(os.Mkdir("assets\\images", 0666))
      check(os.Mkdir("assets\\documents", 0666))
      check(os.Mkdir("lib\\api_web\\models", 0666))
      check(os.Mkdir("lib\\api_web\\schemas", 0666))
      check(os.Mkdir("lib\\api_web\\utilities", 0666))
      adjustFile("mix.exs", "{:phoenix,", "{:corsica, \"~> 1.3\"},\n      {:distillery, \"~> 2.1\"},\n      {:cowlib, \"~> " + getMatch(":hex, :cowlib, \"(.+?)\",", "mix.lock") + "\", override: true},\n      {:certifi, \"~> 2.9\"},\n      {:gun, \"~> 1.3\"},\n      {:absinthe, \"~> 1.7\"},\n      {:absinthe_plug, \"~> 1.5\"},\n      {:absinthe_phoenix, \"~> 2.0\"},\n      {:absinthe_upload, \"~> 0.1.2\"},\n      {:phoenix,")
      check(makeCommandInteractive(exec.Command("mix", "do", "deps.get,", "compile")).Run())
      adjustFile("lib\\api_web\\endpoint.ex", "@session_options]]", "@session_options]]\n\n  plug Corsica, origins: [\"http://127.0.0.1:5173\", \"\"]")

      if len(os.Args) == 4 && os.Args[3] == "intl" {
        adjustFile("config\\config.exs", "import Config", "import Config\n\nconfig :api, ApiWeb.Gettext, default_locale: \"en\", locales: ~w(en es)")
        check(makeCommandInteractive(exec.Command("mix", "gettext.merge", "priv/gettext", "--locale", "en")).Run())
        check(makeCommandInteractive(exec.Command("mix", "gettext.merge", "priv/gettext", "--locale", "es")).Run())
      }

      check(makeCommandInteractive(exec.Command("mix", "distillery.init")).Run())
      check(copyToClipboard(UpdateReadMe(projectType)))
      check(os.Chdir(currentDirectory))
    case "qwik":
      projectType = "pwa"
      check(exec.Command("npm", "i", "-g", "npm").Run())
      check(exec.Command("npm", "create", "qwik@latest", "basic", projectType).Run())
      check(os.Chdir(projectType))
      SetupActions(projectType, "")
      os.RemoveAll("src")
      check(CopyDir("ProjectSettings\\pwa\\src", "src"))
      check(exec.Command("npm", "i").Run())
      check(exec.Command("npm", "uninstall", "prettier").Run())
      check(os.Remove(".prettierignore"))
      check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "partytown")).Run())
      check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "tailwind")).Run())
      check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "vitest")).Run())
      check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "playwright")).Run())
      check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "react")).Run())
      //check(os.RemoveAll("src\\components\\example"))
      //TODO: keep an eye on Qwik react until there's a stable cleanup process

      if len(os.Args) == 6 && os.Args[4] == "static" {
        check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "static")).Run())
        adjustFile("adaptors\\static\\vite.config.ts", "yoursite.qwik.dev", os.Args[5])
      }

      check(makeCommandInteractive(exec.Command("npm", "run", "qwik", "add", "cloudflare-pages")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "rxjs")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "lodash", "@types/lodash")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "graphql")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "three", "@types/three")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "@react-spring/web")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "framer-motion")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "react-p5")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "sass")).Run())
      check(makeCommandInteractive(exec.Command("npm", "i", "wticons")).Run())
      check(os.Mkdir("src\\models", 0666))
      check(os.Mkdir("src\\schemas", 0666))
      check(os.Mkdir("src\\utilities", 0666))
      check(os.Mkdir("src\\web-workers", 0666))
      check(os.Mkdir("src\\service-workers", 0666))
      check(os.Mkdir("assets", 0666))
      check(os.Mkdir("assets\\audio", 0666))
      check(os.Mkdir("assets\\images", 0666))
      check(os.Mkdir("assets\\documents", 0666))
      check(copyToClipboard(UpdateReadMe(projectType)))
      check(os.Chdir(currentDirectory))
    case "maui":
      projectType = "cdp"
      SetupActions(projectType, "")
      check(os.Chdir(currentDirectory))
    default: panic(errors.New("project type not supported"))
  }

  check(CopyDir("Personal\\Init\\ProjectSettings\\.vscode", ".vscode"))
  check(CopyFile("Personal\\Init\\ProjectSettings\\.editorconfig", ".editorconfig"))
  check(exec.Command("code", ".").Run())
  //check(exec.Command("exit").Run())
}

func check(e error) {
  if e != nil {
    fmt.Println(e)
    panic(e)
  }
}

func AppendFileContent(from string, to string, buffer string) {
  input, err := ioutil.ReadFile(from)
  check(err)

  file, err := os.OpenFile(to, os.O_APPEND|os.O_CREATE|os.O_WRONLY, 0666)
  check(err)
  defer func () { check(file.Close()) }()

  _, err = file.WriteString(buffer + string(input))
  check(err)
}

func UpdateReadMe(projectType string) string {
  buffer := "\n\n"

  AppendFileContent("ProjectSettings\\CICD\\" + projectType + ".md", "..\\README.md", buffer)

  switch projectType {
    case "nma":
      return "flutter test test/widget_test.dart && flutter run lib/main.dart"
    case "api":
      return "mix test && iex -S mix phx.server"
    case "pwa":
      return "vitest run && vitest watch && npm run start"
    case "cdp":
      return ""
    case "des":
      return ""
    default :
      return ""
  }
}

func SetupActions(projectType string, detail string) {
  buffer := ""
  _, err := os.Stat("..\\.github")

  if os.IsNotExist(err) {
    check(CopyDir("ProjectSettings\\CICD\\.github", "..\\.github"))
  } else {
    check(err)
    buffer += "\n\n"
  }

  AppendFileContent("ProjectSettings\\CICD\\" + projectType + ".yml", "..\\.github\\workflows\\deploy.yml", buffer)

  switch projectType {
    case "api":
      dir, err := os.Getwd()
      check(err)

      dir = strings.ToLower(filepath.Dir(dir))
      elixirVersion := getMatch("elixir: \"~> (.+?)\",", "mix.exs")
      adjustFile("..\\.github\\workflows\\deploy.yml", "REPLACEPATH", dir)
      adjustFile("..\\.github\\workflows\\deploy.yml", "REPLACEELIXIR", elixirVersion)
      adjustFile("phoenix_static_buildpack.config", "REPLACE", elixirVersion)
      adjustFile("config\\prod.exs", "cache_static_manifest:", "url: [host: \"" + dir + ".gigalixirapp.com\", port: 80], cache_static_manifest:")

      if detail == "null" {
        adjustFile("..\\.github\\workflows\\deploy.yml", "REPLACEMIGRATIONS", "false")
      } else {
        adjustFile("..\\.github\\workflows\\deploy.yml", "REPLACEMIGRATIONS", "true")
      }
  }
}

func getMatch(regex string, file string) (match string) {
  input, err := ioutil.ReadFile(file)
  check(err)

  search := regexp.MustCompile(regex)
  match = search.FindStringSubmatch(string(input))[1]

  return
}

func makeCommandInteractive(command *exec.Cmd) *exec.Cmd {
  command.Stdin = os.Stdin
  command.Stdout = os.Stdout

  return command
}

func adjustFile(file string, original string, replacement string) {
  input, err := ioutil.ReadFile(file)
  check(err)

  check(ioutil.WriteFile(file, []byte(strings.ReplaceAll(string(input), original, replacement)), 0666))
}

func CopyFile(source string, dest string) (err error) {
  sourcefile, err := os.Open(source)

  if err != nil {
    return err
  }

  defer func() {
    err = sourcefile.Close()
  }()

  destfile, err := os.Create(dest)

  if err != nil {
    return err
  }

  defer func() {
    err = destfile.Close()
  }()

  _, err = io.Copy(destfile, sourcefile)

  if err == nil {
    sourceinfo, err := os.Stat(source)

    if err != nil {
      err = os.Chmod(dest, sourceinfo.Mode())
    }
  }

  return nil
}

func CopyDir(source string, dest string) (err error) {
  sourceinfo, err := os.Stat(source)

  if err != nil {
    return err
  }

  err = os.MkdirAll(dest, sourceinfo.Mode())

  if err != nil {
    return err
  }

  directory, _ := os.Open(source)

  objects, err := directory.Readdir(-1)

  for _, obj := range objects {
    sourcefilepointer := source + "/" + obj.Name()
    destinationfilepointer := dest + "/" + obj.Name()

    if obj.IsDir() {
      check(CopyDir(sourcefilepointer, destinationfilepointer))
    } else {
      check(CopyFile(sourcefilepointer, destinationfilepointer))
    }
  }

  return nil
}

const
(
  cfUnicodetext = 13
  gmemMoveable  = 0x0002
)

var
(
  user32                     = syscall.MustLoadDLL("user32")
  openClipboard              = user32.MustFindProc("OpenClipboard")
  closeClipboard             = user32.MustFindProc("CloseClipboard")
  emptyClipboard             = user32.MustFindProc("EmptyClipboard")
  setClipboardData           = user32.MustFindProc("SetClipboardData")

  lstrcpy      = kernel32.NewProc("lstrcpyW")
  globalFree   = kernel32.NewProc("GlobalFree")
  globalLock   = kernel32.NewProc("GlobalLock")
  kernel32     = syscall.NewLazyDLL("kernel32")
  globalAlloc  = kernel32.NewProc("GlobalAlloc")
  globalUnlock = kernel32.NewProc("GlobalUnlock")
)

func waitOpenClipboard() error {
  started := time.Now()
  limit := started.Add(time.Second)

  var r uintptr
  var err error

  for time.Now().Before(limit) {
    r, _, err = openClipboard.Call(0)

    if r != 0 {
      return nil
    }

    time.Sleep(time.Millisecond)
  }

  return err
}

func copyToClipboard(text string) error {
  runtime.LockOSThread()
  defer runtime.UnlockOSThread()

  err := waitOpenClipboard()

  if err != nil {
    return err
  }

  r, _, err := emptyClipboard.Call(0)

  if r == 0 {
    _, _, _ = closeClipboard.Call()
    return err
  }

  data, _ := syscall.UTF16FromString(text)
  h, _, err := globalAlloc.Call(gmemMoveable, uintptr(len(data)*int(unsafe.Sizeof(data[0]))))

  if h == 0 {
    _, _, _ = closeClipboard.Call()
    return err
  }

  defer func() {
    if h != 0 {
      _, _, _ = globalFree.Call(h)
    }
  }()

  l, _, err := globalLock.Call(h)

  if l == 0 {
    _, _, _ = closeClipboard.Call()
    return err
  }

  r, _, err = lstrcpy.Call(l, uintptr(unsafe.Pointer(&data[0])))

  if r == 0 {
    _, _, _ = closeClipboard.Call()
    return err
  }

  r, _, err = globalUnlock.Call(h)

  if r == 0 {
    if err.(syscall.Errno) != 0 {
      _, _, _ = closeClipboard.Call()
      return err
    }
  }

  r, _, err = setClipboardData.Call(cfUnicodetext, h)

  if r == 0 {
    _, _, _ = closeClipboard.Call()
    return err
  }

  h = 0
  closed, _, err := closeClipboard.Call()

  if closed == 0 {
    return err
  }

  return nil
}