open System.IO
open System
open FSharp.Data
open FSharp.Collections


//"C:\\Users\\recs\\OneDrive - Premier Tech\\Bureau\\GEO\\F#\\GeoRename\\rename-sample.csv"

let (+/) (path1: string) (path2: string) : string = Path.Combine(path1, path2)


let Renaming (folderpath: string) (filename: string) (newfilename: string) : unit =
    File.Move(((+/) folderpath filename), ((+/) folderpath newfilename))
    printfn "[+][Old-Name -> New-Name] \t%*s -> \t%*s" 10 filename 10 newfilename
    |> ignore


[<EntryPoint>]
let main args =

    printfn "%s" "[INPUT] Enter the path to the renaming file (format : csv):"
    let csv_file: string = Console.ReadLine()
    printfn "%s" csv_file
    let csv_ = CsvFile.Load(csv_file).Cache()

    csv_.Rows
    |> Seq.iter (fun row ->
        Renaming (row.GetColumn "FolderPath") (row.GetColumn "Filename") (row.GetColumn "NewFilename"))
    printfn "Process completed successfully."
    printfn "Press any key to exit..."
    Console.ReadLine() |> ignore
    0
