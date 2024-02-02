import { Link } from "react-router-dom";
const ChooseAccount = () => {
    return ( 
        <>
            <div className="row">
                <div className="col border"><Link to="../signinasuser"><button className="btn">User</button></Link></div>
                <div className="col border"><Link to="../signinascontractor"><button className="btn">Contractor</button></Link></div>
                <div className="col border"><Link to="../signinascompany"><button className="btn">Company</button></Link></div>
            </div>
        </>
     );
}
 
export default ChooseAccount;