<?php

namespace App\Http\Controllers\Api;

use App\Http\Controllers\Controller;
use App\Models\RealState;
use Illuminate\Http\Request;
use PhpParser\Node\Stmt\TryCatch;

class RealStateController extends Controller
{
    private $realState;

    public function __construct(RealState $realState)
    {
        $this->realState = $realState;
    }

    public function index()
    {
        $realState = $this->realState->paginate('10');

        return response()->json($realState, 200);
    }

    public function store(Request $request)
    {
        $data = $request->all();
        try {
            $realState = $this->realState->create($data); //Mass Asignment

            return response()->json('Imóvel cadastrado com sucesso', 200);

        } catch (\Exception $error) {
            return response()->json(['error' => $error->getMessage()], 401);
        }
    }
}
