import {Link} from 'react-router-dom'

const UNav = () => {
    return ( 
        <nav className="navbar navbar-expand-lg sticky-top bg-info  ">
        <div className="container-fluid">
          <a className="navbar-brand text-white" href="/Home">
            EthioRush
          </a>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNavDropdown"
            aria-controls="navbarNavDropdown"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav">
              <li className="nav-item">
                <Link to='/Home'>
                <button data-mdb-ripple-init type="button " className="btn text-white">
                  Home
                </button>
                </Link>
              </li>
              <li className="nav-item">
                <Link to='../reports'>                
                <button data-mdb-ripple-init type="button" className="btn text-white">
                  My Reports
                </button> 
                </Link>
              </li> 
              <li className="nav-item">
                <Link to='../createreport'>                
                <button data-mdb-ripple-init type="button" className="btn text-white">
                  Create Report
                </button> 
                </Link>
              </li>             
              <li className="nav-item">
                <Link to='../trending'>                
                <button data-mdb-ripple-init type="button" className="btn text-white">
                  Trending Reports
                </button> 
                </Link>
              </li>
              <li className="nav-item">
                <Link to='../'>                
                <button data-mdb-ripple-init type="button" className="btn text-white">
                  Log Out
                </button> 
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
     );
}
 
export default UNav;