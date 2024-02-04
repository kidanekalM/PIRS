import { useEffect, useState } from "react";

export default function Reports(companyId="1", status="0"){
    const [reports,setReports] = useState([]);
    useEffect(() => {
        fetch(`https://localhost:7077/Report/GetByCompany?id=${'1'}&reportStatus=${'0'}`)
          .then(response => response.json())
          .then(data => setReports(data));
      }, []);
    return<>
    {JSON.stringify(reports)}
    </>
}